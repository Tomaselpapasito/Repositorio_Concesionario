
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class AccesoriosModel : PageModel
    {
        private IAccesoriosNegocio IAccesoriosAplicacion;
        private IProductosNegocio IProductosAplicacion;

        public AccesoriosModel(
            IAccesoriosNegocio IAccesoriosAplicacion,
            IProductosNegocio IProductosAplicacion)
        {
            this.IAccesoriosAplicacion = IAccesoriosAplicacion;
            this.IProductosAplicacion = IProductosAplicacion;
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

                Lista = this.IAccesoriosAplicacion.Buscar(Filtro!);
                ListaProductos = this.IProductosAplicacion.Consultar();
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
                ListaProductos = this.IProductosAplicacion.Consultar();
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
                    Actual = IAccesoriosAplicacion.Insertar(Actual!);
                else
                    Actual = IAccesoriosAplicacion.Actualizar(Actual!);
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

                Actual = IAccesoriosAplicacion.Borrar(Actual!);
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
