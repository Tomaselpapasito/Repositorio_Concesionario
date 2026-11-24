using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class CargosPresentacion : ICargosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CargosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Cargos Borrar(Cargos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cargos> Buscar(Cargos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Cargos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cargos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cargos>>(
                "Cargos/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Cargos Insertar(Cargos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<Cargos>(
                "Cargos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}