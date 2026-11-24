using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductosController : ControllerBase
    {
        private IProductosAplicacion IProductosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public ProductosController(IProductosAplicacion IProductosAplicacion)
        {
            this.IProductosAplicacion = IProductosAplicacion;
        }

        [HttpPost]
        public List<Productos> Consultar()
        {
            return this.IProductosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Productos> Buscar(Productos entidad)
        {
            return this.IProductosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Productos Insertar(Productos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProductosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Productos Actualizar(Productos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProductosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Productos Borrar(Productos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProductosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
