using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ServiciosController : ControllerBase
    {
        private IServiciosAplicacion IServiciosAplicacion;

        public ServiciosController(IServiciosAplicacion IServiciosAplicacion)
        {
            this.IServiciosAplicacion = IServiciosAplicacion;
        }

        [HttpPost]
        public List<Servicios > Consultar()
        {
            return this.IServiciosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Servicios > Buscar(Servicios  Servicios )
        {
            return this.IServiciosAplicacion.Buscar(Servicios );
        }
    }
}
