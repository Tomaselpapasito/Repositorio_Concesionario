using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PermisosController : ControllerBase
    {
        private IPermisosAplicacion IPermisosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public PermisosController(IPermisosAplicacion IPermisosAplicacion)
        {
            this.IPermisosAplicacion = IPermisosAplicacion;
        }

        [HttpPost]
        public List<Permisos> Consultar()
        {
            return this.IPermisosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IPermisosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Permisos Insertar(Permisos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPermisosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Permisos Actualizar(Permisos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPermisosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Permisos Borrar(Permisos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPermisosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
