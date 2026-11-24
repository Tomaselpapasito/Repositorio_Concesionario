using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesAplicacion IRolesAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public RolesController(IRolesAplicacion IRolesAplicacion)
        {
            this.IRolesAplicacion = IRolesAplicacion;
        }

        [HttpPost]
        public List<Roles> Consultar()
        {
            return this.IRolesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Roles> Buscar(Roles entidad)
        {
            return this.IRolesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Roles Insertar(Roles entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRolesAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Roles Actualizar(Roles entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRolesAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Roles Borrar(Roles entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRolesAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
