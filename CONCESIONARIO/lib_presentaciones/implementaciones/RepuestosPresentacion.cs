using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class RepuestosPresentacion : IRepuestosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public RepuestosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Repuestos Actualizar(Repuestos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Repuestos>(
                "Repuestos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Repuestos Borrar(Repuestos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Repuestos>(
                "Repuestos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Repuestos> Buscar(Repuestos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Repuestos>>(
                "Repuestos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Repuestos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Repuestos>>(
                "Repuestos/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Repuestos Insertar(Repuestos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Repuestos>(
                "Repuestos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}