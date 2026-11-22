using lib_dominio.Entidades;
using lib_dominio.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace asp_servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccesoriosController : ControllerBase
    {
        private IAccesoriosNegocio IAccesoriosAplicacion;

        public AccesoriosController(IAccesoriosNegocio IAccesoriosAplicacion)
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
            return this.IAccesoriosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Accesorios Actualizar(Accesorios entidad)
        {
            return this.IAccesoriosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Accesorios Borrar(Accesorios entidad)
        {
            return this.IAccesoriosAplicacion.Borrar(entidad);
        }
    }
}
