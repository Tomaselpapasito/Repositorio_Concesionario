using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresAplicacion IProveedoresAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public ProveedoresController(IProveedoresAplicacion IProveedoresAplicacion)
        {
            this.IProveedoresAplicacion = IProveedoresAplicacion;
        }

        [HttpPost]
        public List<Proveedores> Consultar()
        {
            return this.IProveedoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Proveedores> Buscar(Proveedores entidad)
        {
            return this.IProveedoresAplicacion.BuscarPorNombre(entidad);
        }

        [HttpPost]
        public Proveedores Insertar(Proveedores entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProveedoresAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Proveedores Actualizar(Proveedores entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProveedoresAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Proveedores Borrar(Proveedores entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IProveedoresAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
