using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;

namespace asp_front.Pages.Ventanas
{
    public class FacturasModel : PageModel
    {
        private readonly IComunicaciones IComunicaciones;

        public FacturasModel(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Ventas> Ventas { get; set; } = new();


        public override void OnPageHandlerExecuting(
            PageHandlerExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("UsuarioID") == null)
            {
                context.Result = new RedirectToPageResult("/Login");
            }

            base.OnPageHandlerExecuting(context);
        }


        public async Task OnGetAsync()
        {
            Ventas = await IComunicaciones.Ejecutar<List<Ventas>>(
                "Ventas/Consultar",
                new { }
            );
        }


        public async Task<IActionResult> OnPostGenerarPdfAsync(int ventaId)
        {
            if (ventaId <= 0)
                return BadRequest("El número de venta no es válido.");


            var factura = await IComunicaciones.Ejecutar<FacturaVentaDto?>(
                "Ventas/ConsultarFactura",
                new Ventas { ID = ventaId }
            );

            if (factura == null)
                return NotFound("No se encontró la venta solicitada.");


            decimal subtotalBruto =
                factura.Motos.Sum(x => x.PrecioUnitario) +
                factura.Productos.Sum(x => x.PrecioUnitario * x.Cantidad);

            decimal descuentos =
                factura.Motos.Sum(x => x.Descuento) +
                factura.Productos.Sum(x => x.Descuento);

            decimal subtotalNeto =
                factura.Motos.Sum(x => x.Subtotal) +
                factura.Productos.Sum(x => x.Subtotal);


            var cultura = CultureInfo.GetCultureInfo("es-CO");

            string Dinero(decimal valor)
            {
                return valor.ToString("C", cultura);
            }


            var documento = Document.Create(contenedor =>
            {
                contenedor.Page(pagina =>
                {
                    pagina.Size(PageSizes.A4);

                    pagina.Margin(35);

                    pagina.DefaultTextStyle(x => x.FontSize(10));


                    pagina.Header().Column(columna =>
                    {
                        columna.Item()
                            .AlignCenter()
                            .Text("CONCESIONARIO DE MOTOCICLETAS")
                            .FontSize(18)
                            .Bold();

                        columna.Item()
                            .AlignCenter()
                            .Text("FACTURA DE VENTA")
                            .FontSize(14)
                            .Bold();

                        columna.Item()
                            .PaddingTop(8)
                            .LineHorizontal(1)
                            .LineColor(Colors.Grey.Medium);
                    });


                    pagina.Content().PaddingVertical(15).Column(columna =>
                    {
                        columna.Spacing(12);


                        columna.Item().Row(fila =>
                        {
                            fila.RelativeItem().Column(datos =>
                            {
                                datos.Item().Text("Número de factura:")
                                    .Bold();

                                datos.Item().Text(
                                    $"FAC-{factura.ID:D6}"
                                );
                            });

                            fila.RelativeItem().AlignRight().Column(datos =>
                            {
                                datos.Item().Text("Fecha de venta:")
                                    .Bold();

                                datos.Item().Text(
                                    factura.FechaVenta.ToString("dd/MM/yyyy")
                                );
                            });
                        });


                        columna.Item().Border(1)
                            .BorderColor(Colors.Grey.Lighten2)
                            .Padding(10)
                            .Column(datos =>
                            {
                                datos.Spacing(4);

                                datos.Item().Text("DATOS DEL CLIENTE")
                                    .Bold()
                                    .FontSize(12);

                                datos.Item().Text(
                                    $"Nombre: {factura.ClienteNombre}"
                                );

                                datos.Item().Text(
                                    $"Cédula: {factura.ClienteCedula}"
                                );

                                datos.Item().Text(
                                    $"Teléfono: {factura.ClienteTelefono}"
                                );

                                datos.Item().Text(
                                    $"Correo: {factura.ClienteCorreo}"
                                );

                                datos.Item().Text(
                                    $"Dirección: {factura.ClienteDireccion}"
                                );
                            });


                        columna.Item().Border(1)
                            .BorderColor(Colors.Grey.Lighten2)
                            .Padding(10)
                            .Column(datos =>
                            {
                                datos.Spacing(4);

                                datos.Item().Text("DATOS DEL EMPLEADO")
                                    .Bold()
                                    .FontSize(12);

                                datos.Item().Text(
                                    $"Nombre: {factura.EmpleadoNombre}"
                                );

                                datos.Item().Text(
                                    $"Cédula: {factura.EmpleadoCedula}"
                                );

                                datos.Item().Text(
                                    $"Carnet: {factura.EmpleadoCarnet}"
                                );
                            });


                        columna.Item().Text("DETALLE DE LA VENTA")
                            .Bold()
                            .FontSize(12);

                        columna.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4);
                                columnas.RelativeColumn(1);
                                columnas.RelativeColumn(2);
                                columnas.RelativeColumn(2);
                            });


                            tabla.Header(encabezado =>
                            {
                                encabezado.Cell()
                                    .Element(EstiloEncabezado)
                                    .Text("Descripción");

                                encabezado.Cell()
                                    .Element(EstiloEncabezado)
                                    .AlignCenter()
                                    .Text("Cant.");

                                encabezado.Cell()
                                    .Element(EstiloEncabezado)
                                    .AlignRight()
                                    .Text("Precio");

                                encabezado.Cell()
                                    .Element(EstiloEncabezado)
                                    .AlignRight()
                                    .Text("Subtotal");
                            });


                            foreach (var moto in factura.Motos)
                            {
                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Column(datos =>
                                    {
                                        datos.Item().Text(
                                            $"Motocicleta: {moto.Modelo}"
                                        ).Bold();

                                        datos.Item().Text(
                                            $"VIN: {moto.VIN}"
                                        );

                                        datos.Item().Text(
                                            $"Motor: {moto.NumeroMotor}"
                                        );

                                        datos.Item().Text(
                                            $"Color: {moto.Color} - Año: {moto.Anio}"
                                        );

                                        datos.Item().Text(
                                            $"Descuento: {Dinero(moto.Descuento)}"
                                        );
                                    });

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignCenter()
                                    .Text("1");

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(moto.PrecioUnitario));

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(moto.Subtotal));
                            }


                            foreach (var producto in factura.Productos)
                            {
                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Column(datos =>
                                    {
                                        datos.Item().Text(
                                            producto.Nombre
                                        ).Bold();

                                        datos.Item().Text(
                                            $"Código: {producto.Codigo}"
                                        );

                                        datos.Item().Text(
                                            $"Descuento: {Dinero(producto.Descuento)}"
                                        );
                                    });

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignCenter()
                                    .Text(producto.Cantidad.ToString());

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(producto.PrecioUnitario));

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(producto.Subtotal));
                            }
                        });


                        columna.Item()
                            .AlignRight()
                            .Width(270)
                            .Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columnas =>
                                {
                                    columnas.RelativeColumn(2);
                                    columnas.RelativeColumn(2);
                                });

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Text("Subtotal bruto:");

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(subtotalBruto));

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Text("Descuentos:");

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(descuentos));

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Text("Subtotal neto:");

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(subtotalNeto));

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .Text("Impuestos:");

                                tabla.Cell()
                                    .Element(EstiloCelda)
                                    .AlignRight()
                                    .Text(Dinero(factura.Impuestos));

                                tabla.Cell()
                                    .Element(EstiloEncabezado)
                                    .Text("TOTAL:");

                                tabla.Cell()
                                    .Element(EstiloEncabezado)
                                    .AlignRight()
                                    .Text(Dinero(factura.Total));
                            });


                        columna.Item()
                            .PaddingTop(15)
                            .AlignCenter()
                            .Text("Gracias por su compra.")
                            .Bold()
                            .FontSize(12);
                    });


                    pagina.Footer().AlignCenter().Text(texto =>
                    {
                        texto.Span("Factura de venta - ");

                        texto.Span($"FAC-{factura.ID:D6}")
                            .Bold();

                        texto.Span(" - Página ");

                        texto.CurrentPageNumber();

                        texto.Span(" de ");

                        texto.TotalPages();
                    });
                });
            });


            byte[] pdf = documento.GeneratePdf();


            Response.Headers["Content-Disposition"] =
                $"inline; filename=Factura_{factura.ID}.pdf";

            return File(pdf, "application/pdf");
        }

        private static IContainer EstiloEncabezado(IContainer contenedor)
        {
            return contenedor
                .Background(Colors.Grey.Lighten2)
                .Border(1)
                .BorderColor(Colors.Grey.Lighten1)
                .Padding(5)
                .DefaultTextStyle(x => x.Bold());
        }


        private static IContainer EstiloCelda(IContainer contenedor)
        {
            return contenedor
                .BorderBottom(1)
                .BorderColor(Colors.Grey.Lighten2)
                .Padding(5);
        }
    }
}