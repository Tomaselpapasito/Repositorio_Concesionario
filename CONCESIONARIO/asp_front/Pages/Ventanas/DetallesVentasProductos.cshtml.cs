
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class DetallesVentasProductosModel : PageModel
    {
        private readonly IDetallesVentasProductosPresentacion IDetallesVentasProductosPresentacion;
        private readonly IProductosPresentacion IProductosPresentacion;
        private readonly IVentasPresentacion IVentasPresentacion;

        public DetallesVentasProductosModel(
            IDetallesVentasProductosPresentacion detallesVentasProductosPresentacion,
            IProductosPresentacion productosPresentacion,
            IVentasPresentacion ventasPresentacion)
        {
            IDetallesVentasProductosPresentacion = detallesVentasProductosPresentacion;
            IProductosPresentacion = productosPresentacion;
            IVentasPresentacion = ventasPresentacion;
        }

        [BindProperty] public List<DetallesVentasProductos> Lista { get; set; } = new();
        [BindProperty] public DetallesVentasProductos? Filtro { get; set; }
        [BindProperty] public DetallesVentasProductos? Actual { get; set; }

        public List<Productos> Productos { get; set; } = new();
        public List<Ventas> Ventas { get; set; } = new();

        public bool Formulario { get; set; } = false;
        public bool Borrar { get; set; } = false;

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new DetallesVentasProductos();
                Lista = IDetallesVentasProductosPresentacion.Buscar(Filtro);
                Formulario = false;
                Borrar = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Actual = new DetallesVentasProductos();
                Productos = IProductosPresentacion.Consultar();
                Ventas = IVentasPresentacion.Consultar();
                Lista = IDetallesVentasProductosPresentacion.Consultar();
                Formulario = true;
                Borrar = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IDetallesVentasProductosPresentacion.Insertar(Actual);
                else
                    IDetallesVentasProductosPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Productos = IProductosPresentacion.Consultar();
                Ventas = IVentasPresentacion.Consultar();
                Lista = IDetallesVentasProductosPresentacion.Consultar();
                Formulario = true;
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IDetallesVentasProductosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Productos = IProductosPresentacion.Consultar();
                Ventas = IVentasPresentacion.Consultar();
                Lista = IDetallesVentasProductosPresentacion.Consultar();

                Formulario = true;
                Borrar = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(int data)
        {
            try
            {
                Actual = IDetallesVentasProductosPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IDetallesVentasProductosPresentacion.Consultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                IDetallesVentasProductosPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
