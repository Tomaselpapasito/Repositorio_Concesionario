using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesComprasAplicacion
    {
        DetallesCompras Insertar(DetallesCompras entidad, int IdUsuario);
        DetallesCompras Actualizar(DetallesCompras entidad,int  IdUsuario);
        List<DetallesCompras> Consultar();
        List<DetallesCompras> Buscar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad, int IdUsuario);
    }
}