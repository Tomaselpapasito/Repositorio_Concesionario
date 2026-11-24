using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IProductosAplicacion
    {
        Productos Insertar(Productos entidad, int IdUsuario);
        Productos Actualizar(Productos entidad,int  IdUsuario);
        List<Productos> Consultar();
        List<Productos> Buscar(Productos entidad);
        Productos Borrar(Productos entidad, int IdUsuario);
    }
}