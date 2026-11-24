using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IComprasAplicacion
    {
        Compras Insertar(Compras entidad, int IdUsuario);
        Compras Actualizar(Compras entidad,int  IdUsuario);
        List<Compras> Consultar();
        List<Compras> Buscar(Compras entidad);
        Compras Borrar(Compras entidad, int IdUsuario);
    }
}