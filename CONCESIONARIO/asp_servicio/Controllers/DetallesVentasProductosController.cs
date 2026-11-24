using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesVentasProductosController : ControllerBase
    {
        private IDetallesVentasProductosAplicacion IDetallesVentasProductosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public DetallesVentasProductosController(IDetallesVentasProductosAplicacion IDetallesVentasProductosAplicacion)
        {
            this.IDetallesVentasProductosAplicacion = IDetallesVentasProductosAplicacion;
        }

        [HttpPost]
        public List<DetallesVentasProductos> Consultar()
        {
            return this.IDetallesVentasProductosAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad)
        {
            return this.IDetallesVentasProductosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesVentasProductos Insertar(DetallesVentasProductos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasProductosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesVentasProductos Actualizar(DetallesVentasProductos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasProductosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesVentasProductos Borrar(DetallesVentasProductos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesVentasProductosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
