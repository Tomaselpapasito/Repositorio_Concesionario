using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class RolesPresentacion : IRolesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public RolesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Roles> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Roles>>(
                "Roles/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Roles>(
                "Roles/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

      
    }
}