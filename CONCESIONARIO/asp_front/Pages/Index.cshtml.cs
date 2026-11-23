
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages
{
    public class IndexModel : PageModel
    {
        private IUsuariosNegocio IUsuariosNegocio;

        public IndexModel(IUsuariosNegocio IUsuariosNegocio)
        {
            this.IUsuariosNegocio = IUsuariosNegocio;
        }

        public bool EstaLogueado = false;

        [BindProperty]
        public string? NombreUsuario { get; set; }

        [BindProperty]
        public string? Contraseña { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");

            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                NombreUsuario = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(NombreUsuario) ||
                    string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    return;
                }

                Usuarios usuario = new Usuarios
                {
                    NombreUsuario = NombreUsuario,
                    Contraseña = Contraseña
                };

                var usuarios = this.IUsuariosNegocio.Buscar(usuario);

                if (usuarios == null || usuarios.Count == 0)
                {
                    OnPostBtClean();
                    return;
                }

                HttpContext.Session.SetString("Usuario", NombreUsuario!);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
