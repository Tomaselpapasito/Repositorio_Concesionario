using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class ModelosMotosPresentacion : IModelosMotosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ModelosMotosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public ModelosMotos Actualizar(ModelosMotos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<ModelosMotos>(
                "ModelosMotos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public ModelosMotos Borrar(ModelosMotos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<ModelosMotos>(
                "ModelosMotos/Borrar",
                entidad);
            task.Wait();
            return task.Result; 
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
                null!);
            task.Wait();
            return task.Result;
        }

        public ModelosMotos Insertar(ModelosMotos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<ModelosMotos>(
                "ModelosMotos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}