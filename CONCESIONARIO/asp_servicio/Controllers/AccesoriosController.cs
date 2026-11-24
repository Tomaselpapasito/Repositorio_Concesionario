using lib_dominio.Entidades;
using lib_dominio.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccesoriosController : ControllerBase
    {
        private IAccesoriosAplicacion IAccesoriosAplicacion;



        private int ObtenerUsuarioID()
    {
        var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return int.Parse(id!);
    }

    public AccesoriosController(IAccesoriosAplicacion IAccesoriosAplicacion)
        {
            this.IAccesoriosAplicacion = IAccesoriosAplicacion;
        }

        [HttpPost]
        public List<Accesorios> Consultar()
        {
            return this.IAccesoriosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Accesorios> Buscar(Accesorios entidad)
        {
            return this.IAccesoriosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Accesorios Insertar(Accesorios entidad)
        {

            var IdUsuario = ObtenerUsuarioID();
            return this.IAccesoriosAplicacion.Insertar(entidad, IdUsuario);
        }

        [HttpPost]
        public Accesorios Actualizar(Accesorios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IAccesoriosAplicacion.Actualizar(entidad,IdUsuario);
        }

        [HttpPost]
        public Accesorios Borrar(Accesorios entidad)
        {
            var IdUsuario = ObtenerUsuarioID();
            return this.IAccesoriosAplicacion.Borrar(entidad, IdUsuario);
        }
    }
}
