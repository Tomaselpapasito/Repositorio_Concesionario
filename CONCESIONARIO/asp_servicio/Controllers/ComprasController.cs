using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasController : ControllerBase
    {
        private IComprasAplicacion IComprasAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public ComprasController(IComprasAplicacion IComprasAplicacion)
        {
            this.IComprasAplicacion = IComprasAplicacion;
        }

        [HttpPost]
        public List<Compras> Consultar()
        {
            return this.IComprasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Compras> Buscar(Compras entidad)
        {
            return this.IComprasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Compras Insertar(Compras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IComprasAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Compras Actualizar(Compras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IComprasAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Compras Borrar(Compras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IComprasAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
