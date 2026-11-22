using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class PersonasPresentacion : IPersonasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public PersonasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Personas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Personas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios>>(
                "Personas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Usuarios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Usuarios>>(
                "Personas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Personas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) || 
                string.IsNullOrEmpty(entidad.Cedula);
        }
    }
}