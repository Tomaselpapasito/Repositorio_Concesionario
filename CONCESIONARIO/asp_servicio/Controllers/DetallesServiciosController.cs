using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesServiciosController : ControllerBase
    {
        private IDetallesServiciosAplicacion IDetallesServiciosAplicacion;

        public DetallesServiciosController(IDetallesServiciosAplicacion IDetallesServiciosAplicacion)
        {
            this.IDetallesServiciosAplicacion = IDetallesServiciosAplicacion;
        }

        [HttpPost]
        public List<DetallesServicios> Consultar()
        {
            return this.IDetallesServiciosAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesServicios> Buscar(DetallesServicios entidad)
        {
            return this.IDetallesServiciosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesServicios Insertar(DetallesServicios entidad)
        {
            return this.IDetallesServiciosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesServicios Actualizar(DetallesServicios entidad)
        {
            return this.IDetallesServiciosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesServicios Borrar(DetallesServicios entidad)
        {
            return this.IDetallesServiciosAplicacion.Borrar(entidad);
        }
    }
}
