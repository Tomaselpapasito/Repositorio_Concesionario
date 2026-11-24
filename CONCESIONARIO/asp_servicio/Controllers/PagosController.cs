using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        private IPagosAplicacion IPagosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public PagosController(IPagosAplicacion IPagosAplicacion)
        {
            this.IPagosAplicacion = IPagosAplicacion;
        }

        [HttpPost]
        public List<Pagos> Consultar()
        {
            return this.IPagosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IPagosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Pagos Insertar(Pagos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPagosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Pagos Actualizar(Pagos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPagosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Pagos Borrar(Pagos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IPagosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
