using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class MetodosPagosPresentacion : IMetodosPagosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MetodosPagosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
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
                null);
            task.Wait();
            return task.Result;
        }


    }
}