using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FinanciamientosController : ControllerBase
    {
        private IFinanciamientosAplicacion IFinanciamientosAplicacion;

        public FinanciamientosController(IFinanciamientosAplicacion IFinanciamientosAplicacion)
        {
            this.IFinanciamientosAplicacion = IFinanciamientosAplicacion;
        }

        [HttpPost]
        public List<Financiamientos> Consultar()
        {
            return this.IFinanciamientosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Financiamientos> Buscar(Financiamientos entidad)
        {
            return this.IFinanciamientosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Financiamientos Insertar(Financiamientos entidad)
        {
            return this.IFinanciamientosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Financiamientos Actualizar(Financiamientos entidad)
        {
            return this.IFinanciamientosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Financiamientos Borrar(Financiamientos entidad)
        {
            return this.IFinanciamientosAplicacion.Borrar(entidad);
        }
    }
}
