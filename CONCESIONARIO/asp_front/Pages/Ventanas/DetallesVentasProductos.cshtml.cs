
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class DetallesVentasProductosModel : PageModel
    {
        private readonly IDetallesVentasProductosNegocio IDetallesVentasProductosAplicacion;
        private readonly IProductosNegocio IProductosAplicacion;
        private readonly IVentasNegocio IVentasAplicacion;

        public DetallesVentasProductosModel(
            IDetallesVentasProductosNegocio detallesVentasProductosAplicacion,
            IProductosNegocio productosAplicacion,
            IVentasNegocio ventasAplicacion)
        {
            IDetallesVentasProductosAplicacion = detallesVentasProductosAplicacion;
            IProductosAplicacion = productosAplicacion;
            IVentasAplicacion = ventasAplicacion;
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
                Lista = IDetallesVentasProductosAplicacion.Buscar(Filtro);
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
                Productos = IProductosAplicacion.Consultar();
                Ventas = IVentasAplicacion.Consultar();
                Lista = IDetallesVentasProductosAplicacion.Consultar();
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
                    IDetallesVentasProductosAplicacion.Insertar(Actual);
                else
                    IDetallesVentasProductosAplicacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Productos = IProductosAplicacion.Consultar();
                Ventas = IVentasAplicacion.Consultar();
                Lista = IDetallesVentasProductosAplicacion.Consultar();
                Formulario = true;
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IDetallesVentasProductosAplicacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Productos = IProductosAplicacion.Consultar();
                Ventas = IVentasAplicacion.Consultar();
                Lista = IDetallesVentasProductosAplicacion.Consultar();

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
                Actual = IDetallesVentasProductosAplicacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IDetallesVentasProductosAplicacion.Consultar();
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
                IDetallesVentasProductosAplicacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
