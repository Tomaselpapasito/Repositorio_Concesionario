using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class MetodosPagosPresentacion : IMetodosPagosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MetodosPagosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public MetodosPagos Actualizar(MetodosPagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "MetodosPagos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "MetodosPagos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<MetodosPagos> Buscar(MetodosPagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<MetodosPagos>>(
                "MetodosPagos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<MetodosPagos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<MetodosPagos>>(
                "MetodosPagos/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos Insertar(MetodosPagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<MetodosPagos>(
                "MetodosPagos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}