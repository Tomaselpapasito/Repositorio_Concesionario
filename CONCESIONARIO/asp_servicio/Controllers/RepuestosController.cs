using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RepuestosController : ControllerBase
    {
        private IRepuestosAplicacion IRepuestosAplicacion;

        public RepuestosController(IRepuestosAplicacion IRepuestosAplicacion)
        {
            this.IRepuestosAplicacion = IRepuestosAplicacion;
        }

        [HttpPost]
        public List<Repuestos> Consultar()
        {
            return this.IRepuestosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Repuestos> Buscar(Repuestos entidad)
        {
            return this.IRepuestosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Repuestos Insertar(Repuestos entidad)
        {
            return this.IRepuestosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Repuestos Actualizar(Repuestos entidad)
        {
            return this.IRepuestosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Repuestos Borrar(Repuestos entidad)
        {
            return this.IRepuestosAplicacion.Borrar(entidad);
        }
    }
}
