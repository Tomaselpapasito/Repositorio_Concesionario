using lib_dominio.entidades;
using lib_dominio.interfaces;
using lib_presentaciones.interfaces;

namespace lib_presentaciones.implementaciones
{
    public class ModelosMotosPresentacion : IModelosMotosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ModelosMotosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
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


    }
}