using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IComprasAplicacion
    {
        Compras Insertar(Compras entidad);
        Compras Actualizar(Compras entidad);
        List<Compras> Consultar();
        List<Compras> Buscar(Compras entidad);
        Compras Borrar(Compras entidad);
    }
}