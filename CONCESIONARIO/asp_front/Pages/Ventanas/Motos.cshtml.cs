using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Modulos
{
    public class MotosModel : PageModel
    {
        private IMotosNegocio IMotosAplicacion;


        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("UsuarioID") == null)
            {
                context.Result = new RedirectToPageResult("/Login");
            }
        }
        public MotosModel(IMotosNegocio IMotosAplicacion)
        {
            this.IMotosAplicacion = IMotosAplicacion;
            this.Filtro = new Motos();
        }

        [BindProperty] public List<Motos> Lista { get; set; }
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
                Lista = this.IMotosAplicacion.Buscar(Filtro!);
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
                this.Actual = new Motos();
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
                if (this.Actual!.ID == 0)
                    this.Actual = this.IMotosAplicacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IMotosAplicacion.Actualizar(this.Actual!);
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

                this.Actual = this.Lista.FirstOrDefault(
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

                this.Actual = this.Lista.FirstOrDefault(
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
                if (this.Actual!.ID == 0)
                    return;

                this.Actual = this.IMotosAplicacion.Borrar(this.Actual!);
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