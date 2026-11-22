using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesVentasMotosController : ControllerBase
    {
        private IDetallesVentasMotosAplicacion IDetallesVentasMotosAplicacion;

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
            return this.IDetallesVentasMotosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesVentasMotos Actualizar(DetallesVentasMotos entidad)
        {
            return this.IDetallesVentasMotosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesVentasMotos Borrar(DetallesVentasMotos entidad)
        {
            return this.IDetallesVentasMotosAplicacion.Borrar(entidad);
        }
    }
}
