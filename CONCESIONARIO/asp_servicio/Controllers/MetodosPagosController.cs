using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MetodosPagosController : ControllerBase
    {
        private IMetodosPagosAplicacion IMetodosPagosAplicacion;

     
        public MetodosPagosController(IMetodosPagosAplicacion IMetodosPagosAplicacion)
        {
            this.IMetodosPagosAplicacion = IMetodosPagosAplicacion;
        }

        [HttpPost]
        public List<MetodosPagos> Consultar()
        {
            return this.IMetodosPagosAplicacion.Consultar();
        }

        [HttpPost]
        public List<MetodosPagos> Buscar(MetodosPagos entidad)
        {
            return this.IMetodosPagosAplicacion.Buscar(entidad);
        }
       
    }
}
