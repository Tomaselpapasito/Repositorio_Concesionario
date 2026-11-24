using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RepuestosController : ControllerBase
    {
        private IRepuestosAplicacion IRepuestosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public RepuestosController(IRepuestosAplicacion IRepuestosAplicacion)
        {
            this.IRepuestosAplicacion = IRepuestosAplicacion;
        }

        [HttpPost]
        public List<Repuestos> Consultar()
        {
            return this.IRepuestosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Repuestos> Buscar(Repuestos entidad)
        {
            return this.IRepuestosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Repuestos Insertar(Repuestos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRepuestosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Repuestos Actualizar(Repuestos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRepuestosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Repuestos Borrar(Repuestos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IRepuestosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
