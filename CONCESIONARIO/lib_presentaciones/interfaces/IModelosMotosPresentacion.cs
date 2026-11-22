using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IModelosMotosPresentacion
    {
        List<ModelosMotos> Consultar();
        List<ModelosMotos> Buscar(ModelosMotos entidad);
    }
}