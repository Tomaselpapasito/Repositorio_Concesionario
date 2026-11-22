using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IProductosNegocio
    {
        Productos Insertar(Productos entidad);
        Productos Actualizar(Productos entidad);
        List<Productos> Consultar();
        List<Productos> Buscar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}