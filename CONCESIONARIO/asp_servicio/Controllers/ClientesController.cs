using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesNegocio IClientesAplicacion;

        public ClientesController(IClientesNegocio IClientesAplicacion)
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
            return this.IClientesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Clientes Actualizar(Clientes entidad)
        {
            return this.IClientesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Clientes Borrar(Clientes entidad)
        {
            return this.IClientesAplicacion.Borrar(entidad);
        }
    }
}
