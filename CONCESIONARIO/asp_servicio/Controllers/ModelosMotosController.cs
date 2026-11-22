using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ModelosMotosController : ControllerBase
    {
        private IModelosMotosNegocio IModelosMotosAplicacion;

        public ModelosMotosController(IModelosMotosNegocio IModelosMotosAplicacion)
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
