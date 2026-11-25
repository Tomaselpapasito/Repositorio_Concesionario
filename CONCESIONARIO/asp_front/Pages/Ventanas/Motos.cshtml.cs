
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class MotosModel : PageModel
    {
        private IMotosPresentacion IMotosPresentacion;
        private IModelosMotosPresentacion IModelosMotosPresentacion;

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("UsuarioID") == null)
            {
                context.Result = new RedirectToPageResult("/Login");
            }
        }

        public MotosModel(
            IMotosPresentacion IMotosPresentacion,
            IModelosMotosPresentacion IModelosMotosPresentacion)
        {
            this.IMotosPresentacion = IMotosPresentacion;
            this.IModelosMotosPresentacion = IModelosMotosPresentacion;
            this.Filtro = new Motos();
            this.ListaModelos = new List<ModelosMotos>();
        }

        [BindProperty] public List<Motos> Lista { get; set; }
        [BindProperty] public List<ModelosMotos> ListaModelos { get; set; }
        [BindProperty] public Motos? Filtro { get; set; }
        [BindProperty] public Motos? Actual { get; set; }
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
                Filtro!.VIN = Filtro.VIN ?? "";
                Filtro.Numero_Motor = Filtro.Numero_Motor ?? "";
                Filtro.Estado = Filtro.Estado ?? "";

                Lista = this.IMotosPresentacion.Buscar(Filtro!);
                ListaModelos = this.IModelosMotosPresentacion.Consultar();
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
                Actual = new Motos();
                ListaModelos = this.IModelosMotosPresentacion.Consultar();
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
                    Actual = this.IMotosPresentacion.Insertar(Actual!);
                else
                    Actual = this.IMotosPresentacion.Actualizar(Actual!);
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

                ListaModelos = this.IModelosMotosPresentacion.Consultar();
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

                Actual = this.IMotosPresentacion.Borrar(Actual!);
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
