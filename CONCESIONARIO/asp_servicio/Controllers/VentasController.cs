using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VentasController : ControllerBase
    {
        private IVentasNegocio IVentasAplicacion;
        private IConexion IConexion;

        public VentasController(
            IVentasNegocio IVentasAplicacion,
            IConexion IConexion)
        {
            this.IVentasAplicacion = IVentasAplicacion;
            this.IConexion = IConexion;
        }

        [HttpPost]
        public List<Ventas> Consultar()
        {
            return this.IVentasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Ventas> Buscar(Ventas entidad)
        {
            return this.IVentasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Ventas Insertar(Ventas entidad)
        {
            return this.IVentasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Ventas Actualizar(Ventas entidad)
        {
            return this.IVentasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Ventas Borrar(Ventas entidad)
        {
            return this.IVentasAplicacion.Borrar(entidad);
        }


        [HttpPost]
        public FacturaVentaDto? ConsultarFactura(Ventas entidad)
        {
            var venta = this.IConexion.Ventas!
                .AsNoTracking()
                .Include(x => x._Cliente)
                    .ThenInclude(x => x!._Persona)
                .Include(x => x._Empleado)
                    .ThenInclude(x => x!._Persona)
                .FirstOrDefault(x => x.ID == entidad.ID);

            if (venta == null)
                return null;


            var detallesMotos = this.IConexion.DetallesVentasMotos!
                .AsNoTracking()
                .Include(x => x._Moto)
                    .ThenInclude(x => x!._Modelo)
                .Where(x => x.Venta == venta.ID)
                .ToList();


            var detallesProductos = this.IConexion.DetallesVentasProductos!
                .AsNoTracking()
                .Include(x => x._Producto)
                .Where(x => x.Venta == venta.ID)
                .ToList();

            var factura = new FacturaVentaDto
            {
                ID = venta.ID,

                FechaVenta = venta.Fecha_Venta,

                Impuestos = venta.Impuestos,

                Total = venta.Total,

                ClienteNombre =
                    venta._Cliente?._Persona?.Nombre ?? "",

                ClienteCedula =
                    venta._Cliente?._Persona?.Cedula ?? "",

                ClienteTelefono =
                    venta._Cliente?._Persona?.Telefono ?? "",

                ClienteCorreo =
                    venta._Cliente?.Correo ?? "",

                ClienteDireccion =
                    venta._Cliente?.Direccion ?? "",

                EmpleadoNombre =
                    venta._Empleado?._Persona?.Nombre ?? "",

                EmpleadoCedula =
                    venta._Empleado?._Persona?.Cedula ?? "",

                EmpleadoCarnet =
                    venta._Empleado?.Carnet ?? ""
            };


            foreach (var detalle in detallesMotos)
            {
                factura.Motos.Add(new FacturaMotoDto
                {
                    Modelo =
                        detalle._Moto?._Modelo?.Nombre ?? "",

                    VIN =
                        detalle._Moto?.VIN ?? "",

                    NumeroMotor =
                        detalle._Moto?.Numero_Motor ?? "",

                    Color =
                        detalle._Moto?.Color ?? "",

                    Anio =
                        detalle._Moto?.Anio ?? 0,

                    PrecioUnitario =
                        detalle.Precio_Unitario,

                    Descuento =
                        detalle.Descuento,

                    Subtotal =
                        detalle.Subtotal
                });
            }

            foreach (var detalle in detallesProductos)
            {
                factura.Productos.Add(new FacturaProductoDto
                {
                    Codigo =
                        detalle._Producto?.Codigo ?? "",

                    Nombre =
                        detalle._Producto?.Nombre ?? "",

                    Cantidad =
                        detalle.Cantidad,

                    PrecioUnitario =
                        detalle.Precio_Unitario,

                    Descuento =
                        detalle.Descuento,

                    Subtotal =
                        detalle.Subtotal
                });
            }

            return factura;
        }
    }
}