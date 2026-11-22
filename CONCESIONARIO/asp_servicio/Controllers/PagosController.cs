using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PagosController : ControllerBase
    {
        private IPagosNegocio IPagosAplicacion;

        public PagosController(IPagosNegocio IPagosAplicacion)
        {
            this.IPagosAplicacion = IPagosAplicacion;
        }

        [HttpPost]
        public List<Pagos> Consultar()
        {
            return this.IPagosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IPagosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Pagos Insertar(Pagos entidad)
        {
            return this.IPagosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Pagos Actualizar(Pagos entidad)
        {
            return this.IPagosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Pagos Borrar(Pagos entidad)
        {
            return this.IPagosAplicacion.Borrar(entidad);
        }
    }
}
