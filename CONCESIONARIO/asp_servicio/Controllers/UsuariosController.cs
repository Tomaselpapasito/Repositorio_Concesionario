using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosAplicacion IUsuariosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public UsuariosController(IUsuariosAplicacion IUsuariosAplicacion)
        {
            this.IUsuariosAplicacion = IUsuariosAplicacion;
        }

        [HttpPost]
        public List<Usuarios> Consultar()
        {
            return this.IUsuariosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IUsuariosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Usuarios Insertar(Usuarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IUsuariosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Usuarios Actualizar(Usuarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IUsuariosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Usuarios Borrar(Usuarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IUsuariosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
