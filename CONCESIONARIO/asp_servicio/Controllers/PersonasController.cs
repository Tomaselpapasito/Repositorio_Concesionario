using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        private IPersonasAplicacion IPersonasAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public PersonasController(IPersonasAplicacion IPersonasAplicacion)
        {
            this.IPersonasAplicacion = IPersonasAplicacion;
        }

        [HttpPost]
        public List<Personas> Consultar()
        {
            return this.IPersonasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Personas> Buscar(Personas entidad)
        {
            return this.IPersonasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Personas Insertar(Personas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPersonasAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Personas Actualizar(Personas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPersonasAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Personas Borrar(Personas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPersonasAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
