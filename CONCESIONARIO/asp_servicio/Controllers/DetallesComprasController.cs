using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesComprasController : ControllerBase
    {
        private IDetallesComprasAplicacion IDetallesComprasAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public DetallesComprasController(IDetallesComprasAplicacion IDetallesComprasAplicacion)
        {
            this.IDetallesComprasAplicacion = IDetallesComprasAplicacion;
        }

        [HttpPost]
        public List<DetallesCompras> Consultar()
        {
            return this.IDetallesComprasAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesComprasAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesComprasAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IDetallesComprasAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
