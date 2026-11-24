using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion IClientesAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }


        public ClientesController(IClientesAplicacion IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
        }

        [HttpPost]
        public List<Clientes> Consultar()
        {
            return this.IClientesAplicacion.Consultar();
        }

        [HttpPost]
        public Clientes Buscar(Clientes entidad)
        {
            return this.IClientesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Clientes Insertar(Clientes entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IClientesAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Clientes Actualizar(Clientes entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IClientesAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Clientes Borrar(Clientes entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IClientesAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
