
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages.Ventanas
{
    public class ClientesModel : PageModel
    {
        private IClientesNegocio IClientesAplicacion;



        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (HttpContext.Session.GetInt32("UsuarioID") == null)
            {
                context.Result = new RedirectToPageResult("/Login");
            }
        }
        public ClientesModel(IClientesNegocio IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
            this.Filtro = new Clientes();
        }

        [BindProperty] public List<Clientes> Lista { get; set; }
        [BindProperty] public Clientes? Filtro { get; set; }
        [BindProperty] public Clientes? Actual { get; set; }
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
                Filtro!.Correo = Filtro.Correo ?? "";
                Filtro.Numero_Licencia = Filtro.Numero_Licencia ?? "";
                Filtro.Direccion = Filtro.Direccion ?? "";

                Actual = this.IClientesAplicacion.Buscar(Filtro!);
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
                this.Actual = new Clientes();
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
                    this.Actual = this.IClientesAplicacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IClientesAplicacion.Actualizar(this.Actual!);
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

                this.Actual = this.IClientesAplicacion.Borrar(this.Actual!);
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