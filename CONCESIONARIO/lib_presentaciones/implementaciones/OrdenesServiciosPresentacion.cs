using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class OrdenesServiciosPresentacion : IOrdenesServiciosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public OrdenesServiciosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public OrdenesServicios Actualizar(OrdenesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<OrdenesServicios>(
                "OrdenesServicios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public OrdenesServicios Borrar(OrdenesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<OrdenesServicios>(
                "OrdenesServicios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<OrdenesServicios> Buscar(OrdenesServicios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<OrdenesServicios>>(
                "OrdenesServicios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<OrdenesServicios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<OrdenesServicios>>(
                "OrdenesServicios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public OrdenesServicios Insertar(OrdenesServicios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<OrdenesServicios>(
                "OrdenesServicios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(OrdenesServicios entidad)
        {
            return entidad.Cliente == 0 ||
                entidad.Empleado == 0 ||
                entidad.Moto == 0;
        }
    }
}