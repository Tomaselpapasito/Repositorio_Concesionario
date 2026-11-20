using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IProductosAplicacion
    {
        Productos Insertar(Productos entidad);
        Productos Actualizar(Productos entidad);
        List<Productos> Consultar();
        List<Productos> Buscar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}