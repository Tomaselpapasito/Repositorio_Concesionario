using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControllerBase
    {
        private IInventariosAplicacion IInventariosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public InventariosController(IInventariosAplicacion IInventariosAplicacion)
        {
            this.IInventariosAplicacion = IInventariosAplicacion;
        }

        [HttpPost]
        public List<Inventarios> Consultar()
        {
            return this.IInventariosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Inventarios> Buscar(Inventarios entidad)
        {
            return this.IInventariosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Inventarios Insertar(Inventarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IInventariosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Inventarios Actualizar(Inventarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IInventariosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Inventarios Borrar(Inventarios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IInventariosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
