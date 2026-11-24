using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosAplicacion IEmpleadosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public EmpleadosController(IEmpleadosAplicacion IEmpleadosAplicacion)
        {
            this.IEmpleadosAplicacion = IEmpleadosAplicacion;
        }

        [HttpPost]
        public List<Empleados> Consultar()
        {
            return this.IEmpleadosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Empleados> Buscar(Empleados entidad)
        {
            return this.IEmpleadosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Empleados Insertar(Empleados entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IEmpleadosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Empleados Actualizar(Empleados entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IEmpleadosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Empleados Borrar(Empleados entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IEmpleadosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
