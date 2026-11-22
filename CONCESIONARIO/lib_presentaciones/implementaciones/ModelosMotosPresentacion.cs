using lib_dominio.Entidades;
using lib_dominio.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ModelosMotosPresentacion : IModelosMotosNegocio
    {
        private IComunicaciones IComunicaciones;

        public ModelosMotosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public ModelosMotos Actualizar(ModelosMotos entidad)
        {
            throw new NotImplementedException();
        }

        public ModelosMotos Borrar(ModelosMotos entidad)
        {
            throw new NotImplementedException();
        }

        public List<ModelosMotos> Buscar(ModelosMotos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<ModelosMotos>>(
                "ModelosMotos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ModelosMotos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<ModelosMotos>>(
                "ModelosMotos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public ModelosMotos Insertar(ModelosMotos entidad)
        {
            throw new NotImplementedException();
        }
    }
}