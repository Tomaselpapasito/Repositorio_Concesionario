using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IModelosMotosNegocio
    {
        ModelosMotos Insertar(ModelosMotos entidad);
        ModelosMotos Actualizar(ModelosMotos entidad);
        List<ModelosMotos> Consultar();
        List<ModelosMotos> Buscar(ModelosMotos entidad);
        ModelosMotos Borrar(ModelosMotos entidad);
    }
}