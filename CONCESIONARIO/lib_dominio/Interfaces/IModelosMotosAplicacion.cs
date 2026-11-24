using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IModelosMotosAplicacion
    {
        ModelosMotos Insertar(ModelosMotos entidad, int IdUsuario);
        ModelosMotos Actualizar(ModelosMotos entidad,int  IdUsuario);
        List<ModelosMotos> Consultar();
        List<ModelosMotos> Buscar(ModelosMotos entidad);
        ModelosMotos Borrar(ModelosMotos entidad, int IdUsuario);
    }
}