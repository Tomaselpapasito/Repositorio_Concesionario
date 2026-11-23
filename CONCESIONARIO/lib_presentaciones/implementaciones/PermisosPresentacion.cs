using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class PermisosPresentacion : IPermisosNegocio
    {
        private IComunicaciones IComunicaciones;

        public PermisosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Permisos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Permisos>>(
                "Permisos/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Permisos>(
                "Permisos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

      
    }
}