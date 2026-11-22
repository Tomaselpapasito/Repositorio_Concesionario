using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrdenesServiciosController : ControllerBase
    {
        private IOrdenesServiciosAplicacion IOrdenesServiciosAplicacion;

        public OrdenesServiciosController(IOrdenesServiciosAplicacion IOrdenesServiciosAplicacion)
        {
            this.IOrdenesServiciosAplicacion = IOrdenesServiciosAplicacion;
        }

        [HttpPost]
        public List<OrdenesServicios> Consultar()
        {
            return this.IOrdenesServiciosAplicacion.Consultar();
        }

        [HttpPost]
        public List<OrdenesServicios> Buscar(OrdenesServicios entidad)
        {
            return this.IOrdenesServiciosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public OrdenesServicios Insertar(OrdenesServicios entidad)
        {
            return this.IOrdenesServiciosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public OrdenesServicios Actualizar(OrdenesServicios entidad)
        {
            return this.IOrdenesServiciosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public OrdenesServicios Borrar(OrdenesServicios entidad)
        {
            return this.IOrdenesServiciosAplicacion.Borrar(entidad);
        }
    }
}
