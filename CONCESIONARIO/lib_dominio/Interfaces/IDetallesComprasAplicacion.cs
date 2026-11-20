using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IDetallesComprasAplicacion
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        DetallesCompras Actualizar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        List<DetallesCompras> Buscar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}