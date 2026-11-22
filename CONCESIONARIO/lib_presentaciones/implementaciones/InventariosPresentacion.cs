using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class InventariosPresentacion : IInventariosNegocio
    {
        private IComunicaciones IComunicaciones;

        public InventariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Inventarios Actualizar(Inventarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventarios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios Borrar(Inventarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventarios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> Buscar(Inventarios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Inventarios>>(
                "Inventarios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Inventarios>>(
                "Inventarios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Inventarios Insertar(Inventarios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Inventarios>(
                "Inventarios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}