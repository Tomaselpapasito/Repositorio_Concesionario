
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class AccesoriosModel : PageModel
    {
        private IAccesoriosPresentacion IAccesoriosPresentacion;
        private IProductosPresentacion IProductosPresentacion;

        public AccesoriosModel(
            IAccesoriosPresentacion IAccesoriosPresentacion,
            IProductosPresentacion IProductosPresentacion)
        {
            this.IAccesoriosPresentacion = IAccesoriosPresentacion;
            this.IProductosPresentacion = IProductosPresentacion;
            this.Filtro = new Accesorios();
            this.ListaProductos = new List<Productos>();
        }

        [BindProperty] public List<Accesorios> Lista { get; set; }
        [BindProperty] public List<Productos> ListaProductos { get; set; }
        [BindProperty] public Accesorios? Filtro { get; set; }
        [BindProperty] public Accesorios? Actual { get; set; }
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
                Filtro!.Nombre = Filtro.Nombre ?? "";
                Filtro.Categoria = Filtro.Categoria ?? "";
                Filtro.Marca = Filtro.Marca ?? "";

                Lista = this.IAccesoriosPresentacion.Buscar(Filtro!);
                ListaProductos = this.IProductosPresentacion.Consultar();
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
                Formulario = true;
                Actual = new Accesorios();
                ListaProductos = this.IProductosPresentacion.Consultar();
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
                    Actual = IAccesoriosPresentacion.Insertar(Actual!);
                else
                    Actual = IAccesoriosPresentacion.Actualizar(Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();

                Actual = Lista.FirstOrDefault(
                    x => x.ID == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();

                Actual = Lista.FirstOrDefault(
                    x => x.ID == Convert.ToInt32(data));
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
                if (Actual!.ID == 0)
                    return;

                Actual = IAccesoriosPresentacion.Borrar(Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
