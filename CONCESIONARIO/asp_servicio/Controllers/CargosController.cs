using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CargosController : ControllerBase
    {
        private ICargosAplicacion ICargosAplicacion;

        public CargosController(ICargosAplicacion ICargosAplicacion)
        {
            this.ICargosAplicacion = ICargosAplicacion;
        }

        [HttpPost]
        public List<Cargos> Consultar()
        {
            return this.ICargosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Cargos> Buscar(Cargos Cargos)
        {
            return this.ICargosAplicacion.Buscar(Cargos);
        }
    }
}
