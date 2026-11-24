using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FinanciamientosController : ControllerBase
    {
        private IFinanciamientosAplicacion IFinanciamientosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

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
            var IdUsuario = ObtenerUsuarioID();
            return this.IFinanciamientosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Financiamientos Actualizar(Financiamientos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IFinanciamientosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Financiamientos Borrar(Financiamientos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IFinanciamientosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
