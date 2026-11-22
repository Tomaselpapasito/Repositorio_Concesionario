using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class VentasPresentacion : IVentasNegocio
    {
        private IComunicaciones IComunicaciones;

        public VentasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Ventas Actualizar(Ventas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Ventas Borrar(Ventas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Ventas> Buscar(Ventas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Ventas>>(
                "Ventas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Ventas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Ventas>>(
                "Ventas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Ventas Insertar(Ventas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ventas>(
                "Ventas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

    }
}