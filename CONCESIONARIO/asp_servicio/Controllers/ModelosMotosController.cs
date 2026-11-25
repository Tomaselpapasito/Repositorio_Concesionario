
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ModelosMotosController : ControllerBase
    {
        private IModelosMotosAplicacion IModelosMotosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

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

        [HttpPost]
        public ModelosMotos Insertar(ModelosMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IModelosMotosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public ModelosMotos Actualizar(ModelosMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IModelosMotosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public ModelosMotos Borrar(ModelosMotos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IModelosMotosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
