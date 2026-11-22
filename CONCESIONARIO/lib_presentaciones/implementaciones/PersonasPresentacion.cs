using lib_dominio.Entidades;
using lib_dominio.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class PersonasPresentacion : IPersonasNegocio
    {
        private IComunicaciones IComunicaciones;

        public PersonasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Personas Actualizar(Personas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Personas> Buscar(Personas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Personas>>(
                "Personas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Personas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Personas>>(
                "Personas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Personas Insertar(Personas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Personas>(
                "Personas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}