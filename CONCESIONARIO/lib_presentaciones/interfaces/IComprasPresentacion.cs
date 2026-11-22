using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface IComprasPresentacion
    {
        Compras Insertar(Compras entidad);
        Compras Actualizar(Compras entidad);
        List<Compras> Consultar();
        List<Compras> Buscar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}