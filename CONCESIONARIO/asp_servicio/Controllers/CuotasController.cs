using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CuotasController : ControllerBase
    {
        private ICuotasAplicacion ICuotasAplicacion;

        private int ObtenerUsuarioID()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(id!);
        }

        public CuotasController(ICuotasAplicacion ICuotasAplicacion)
        {
            this.ICuotasAplicacion = ICuotasAplicacion;
        }

        [HttpPost]
        public List<Cuotas> Consultar()
        {
            return this.ICuotasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Cuotas> Buscar(Cuotas entidad)
        {
            return this.ICuotasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Cuotas Insertar(Cuotas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.ICuotasAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Cuotas Actualizar(Cuotas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.ICuotasAplicacion.Actualizar(entidad, IdUsuario);
        }

        [HttpPost]
        public Cuotas Borrar(Cuotas entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.ICuotasAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
