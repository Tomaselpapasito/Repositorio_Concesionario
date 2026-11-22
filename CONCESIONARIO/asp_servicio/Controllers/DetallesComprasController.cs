using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesComprasController : ControllerBase
    {
        private IDetallesComprasNegocio IDetallesComprasAplicacion;

        public DetallesComprasController(IDetallesComprasNegocio IDetallesComprasAplicacion)
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
            return this.IDetallesComprasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Borrar(entidad);
        }
    }
}
