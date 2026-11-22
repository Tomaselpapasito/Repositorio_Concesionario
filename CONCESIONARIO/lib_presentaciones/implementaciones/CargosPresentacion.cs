using lib_dominio.Entidades;
using lib_dominio.Interfaces;


namespace lib_presentaciones.Implementaciones
{
    public class CargosPresentacion : ICargosNegocio
    {
        private IComunicaciones IComunicaciones;

        public CargosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            throw new NotImplementedException();
        }

        public Cargos Borrar(Cargos entidad)
        {
            throw new NotImplementedException();
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
                null);
            task.Wait();
            return task.Result;
        }

        public Cargos Insertar(Cargos entidad)
        {
            throw new NotImplementedException();
        }
    }
}