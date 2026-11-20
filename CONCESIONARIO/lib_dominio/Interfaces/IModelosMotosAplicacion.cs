using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IModelosMotosAplicacion
    {
        ModelosMotos Insertar(ModelosMotos entidad);
        ModelosMotos Actualizar(ModelosMotos entidad);
        List<ModelosMotos> Consultar();
        List<ModelosMotos> Buscar(ModelosMotos entidad);
        ModelosMotos Borrar(ModelosMotos entidad);
    }
}