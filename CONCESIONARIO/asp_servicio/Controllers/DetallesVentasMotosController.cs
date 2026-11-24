using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesVentasMotosController : ControllerBase
    {
        private IDetallesVentasMotosAplicacion IDetallesVentasMotosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public DetallesVentasMotosController(IDetallesVentasMotosAplicacion IDetallesVentasMotosAplicacion)
        {
            this.IDetallesVentasMotosAplicacion = IDetallesVentasMotosAplicacion;
        }

        [HttpPost]
        public List<DetallesVentasMotos> Consultar()
        {
            return this.IDetallesVentasMotosAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad)
        {
            return this.IDetallesVentasMotosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesVentasMotos Insertar(DetallesVentasMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasMotosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesVentasMotos Actualizar(DetallesVentasMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasMotosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesVentasMotos Borrar(DetallesVentasMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasMotosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
