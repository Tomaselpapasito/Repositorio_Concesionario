
using lib_dominio.Entidades;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_front.Pages
{
    public class LoginModel : PageModel
    {
        private IAutenticacionPresentacion IAutenticacionPresentacion;

        public LoginModel(
            IAutenticacionPresentacion IAutenticacionPresentacion)
        {
            this.IAutenticacionPresentacion = IAutenticacionPresentacion;
        }

        [BindProperty]
        public string Usuario { get; set; } = "";

        [BindProperty]
        public string Contrasena { get; set; } = "";

        public string? Error { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("UsuarioID") != null)
                return RedirectToPage("/Index");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Usuario) ||
                string.IsNullOrWhiteSpace(Contrasena))
            {
                Error = "Ingrese el usuario y la contraseña.";
                return Page();
            }

            try
            {
                var credenciales = new CredencialesUsuario
                {
                    Usuario = Usuario,
                    Contrasena = Contrasena
                };

                var sesion = await IAutenticacionPresentacion
                    .IniciarSesion(credenciales);

                HttpContext.Session.SetInt32("UsuarioID", sesion.ID);
                HttpContext.Session.SetString("NombreUsuario", sesion.NombreUsuario);
                HttpContext.Session.SetString("Token", sesion.Token);

                return RedirectToPage("/Index");
            }
            catch
            {
                Error = "Usuario o contraseña incorrectos, o no fue posible conectar con el servidor.";
                return Page();
            }
        }
    }
}
