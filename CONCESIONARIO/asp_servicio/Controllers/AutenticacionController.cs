using asp_servicio.Servicios;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutenticacionController : ControllerBase
    {
        private IAutenticacion IAutenticacion;
        private TokenServicio TokenServicio;

        public AutenticacionController(
            IAutenticacion IAutenticacion,
            TokenServicio TokenServicio)
        {
            this.IAutenticacion = IAutenticacion;
            this.TokenServicio = TokenServicio;
        }

        [HttpPost]
        public IActionResult IniciarSesion(
            CredencialesUsuario credenciales)
        {
            var usuario = this.IAutenticacion.IniciarSesion(
                credenciales.Usuario,
                credenciales.Contrasena
            );

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas");

            var token = this.TokenServicio.GenerarToken(usuario);

            return Ok(new SesionUsuario
            {
                ID = usuario.ID,
                NombreUsuario = usuario.NombreUsuario!,
                Token = token
            });
        }
    }
}
