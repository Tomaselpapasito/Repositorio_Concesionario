
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class DetallesComprasModel : PageModel
    {
        private IDetallesComprasPresentacion IDetallesComprasPresentacion;
        private IComprasPresentacion IComprasPresentacion;
        private IProductosPresentacion IProductosPresentacion;

        public DetallesComprasModel(
            IDetallesComprasPresentacion IDetallesComprasPresentacion,
            IComprasPresentacion IComprasPresentacion,
            IProductosPresentacion IProductosPresentacion)
        {
            this.IDetallesComprasPresentacion = IDetallesComprasPresentacion;
            this.IComprasPresentacion = IComprasPresentacion;
            this.IProductosPresentacion = IProductosPresentacion;
        }

        [BindProperty] public List<DetallesCompras> Lista { get; set; } = new();
        [BindProperty] public List<Compras> ListaCompras { get; set; } = new();
        [BindProperty] public List<Productos> ListaProductos { get; set; } = new();
        [BindProperty] public DetallesCompras? Filtro { get; set; }
        [BindProperty] public DetallesCompras? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet()
        {
            OnPostBtConsultar();
        }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new DetallesCompras();

                Lista = IDetallesComprasPresentacion.Buscar(Filtro);
                ListaCompras = IComprasPresentacion.Consultar();
                ListaProductos = IProductosPresentacion.Consultar();

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
            Actual = new DetallesCompras();
            Formulario = true;
            Borrar = false;
            Lista = IDetallesComprasPresentacion.Consultar();
            ListaCompras = IComprasPresentacion.Consultar();
            ListaProductos = IProductosPresentacion.Consultar();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Actual!.ID == 0)
                    IDetallesComprasPresentacion.Insertar(Actual);
                else
                    IDetallesComprasPresentacion.Actualizar(Actual);

                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
                Formulario = true;
                Lista = IDetallesComprasPresentacion.Consultar();
                ListaCompras = IComprasPresentacion.Consultar();
                ListaProductos = IProductosPresentacion.Consultar();
            }
        }

        public void OnPostBtEditar(int data)
        {
            try
            {
                Actual = IDetallesComprasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Formulario = true;
                Borrar = false;
                Lista = IDetallesComprasPresentacion.Consultar();
                ListaCompras = IComprasPresentacion.Consultar();
                ListaProductos = IProductosPresentacion.Consultar();
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
                Actual = IDetallesComprasPresentacion.Consultar()
                    .FirstOrDefault(x => x.ID == data);

                Borrar = true;
                Formulario = false;
                Lista = IDetallesComprasPresentacion.Consultar();
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
                IDetallesComprasPresentacion.Borrar(Actual!);
                OnPostBtConsultar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
