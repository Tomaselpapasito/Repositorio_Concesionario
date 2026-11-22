using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ModelosMotosController : ControllerBase
    {
        private IModelosMotosAplicacion IModelosMotosAplicacion;

        public ModelosMotosController(IModelosMotosAplicacion IModelosMotosAplicacion)
        {
            this.IModelosMotosAplicacion = IModelosMotosAplicacion;
        }

        [HttpPost]
        public List<ModelosMotos> Consultar()
        {
            return this.IModelosMotosAplicacion.Consultar();
        }

        [HttpPost]
        public List<ModelosMotos> Buscar(ModelosMotos ModelosMotos)
        {
            return this.IModelosMotosAplicacion.Buscar(ModelosMotos);
        }
    }
}
