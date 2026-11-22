using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class DetallesServiciosPresentacion : IDetallesServiciosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetallesServiciosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetallesServicios Actualizar(DetallesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesServicios>(
                "DetallesServicios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesServicios Borrar(DetallesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<DetallesServicios>(
                "DetallesServicios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesServicios> Buscar(DetallesServicios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesServicios>>(
                "DetallesServicios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesServicios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetallesServicios>>(
                "DetallesServicios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesServicios Insertar(DetallesServicios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<DetallesServicios>(
                "DetallesServicios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetallesServicios entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Orden == 0 ||
                entidad.Servicio == 0;
        }
    }
}