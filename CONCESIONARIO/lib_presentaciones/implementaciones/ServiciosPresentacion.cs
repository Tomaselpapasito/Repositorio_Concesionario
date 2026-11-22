using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class ServiciosPresentacion : IServiciosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ServiciosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public List<Servicios> Buscar(Servicios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Servicios>>(
                "Servicios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Servicios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Servicios>>(
                "Servicios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }


    }
}