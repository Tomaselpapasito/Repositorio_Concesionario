using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesVentasProductosController : ControllerBase
    {
        private IDetallesVentasProductosAplicacion IDetallesVentasProductosAplicacion;

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
            return this.IDetallesVentasProductosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesVentasProductos Actualizar(DetallesVentasProductos entidad)
        {
            return this.IDetallesVentasProductosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesVentasProductos Borrar(DetallesVentasProductos entidad)
        {
            return this.IDetallesVentasProductosAplicacion.Borrar(entidad);
        }
    }
}
