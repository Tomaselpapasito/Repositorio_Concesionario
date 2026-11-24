using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MotosController : ControllerBase
    {
        private IMotosAplicacion IMotosAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }


        public MotosController(IMotosAplicacion IMotosAplicacion)
        {
            this.IMotosAplicacion = IMotosAplicacion;
        }

        [HttpPost]
        public List<Motos> Consultar()
        {
            return this.IMotosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Motos> Buscar(Motos entidad)
        {
            return this.IMotosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Motos Insertar(Motos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IMotosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Motos Actualizar(Motos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IMotosAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Motos Borrar(Motos entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IMotosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
