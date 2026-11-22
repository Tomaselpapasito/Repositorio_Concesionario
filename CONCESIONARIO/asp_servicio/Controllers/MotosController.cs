using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MotosController : ControllerBase
    {
        private IMotosNegocio IMotosAplicacion;

        public MotosController(IMotosNegocio IMotosAplicacion)
        {
            this.IMotosAplicacion = IMotosAplicacion;
        }

        [HttpPost]
        public List<Motos> Consultar()
        {
            return this.IMotosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Motos> Buscar(Motos entidad)
        {
            return this.IMotosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Motos Insertar(Motos entidad)
        {
            return this.IMotosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Motos Actualizar(Motos entidad)
        {
            return this.IMotosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Motos Borrar(Motos entidad)
        {
            return this.IMotosAplicacion.Borrar(entidad);
        }
    }
}
