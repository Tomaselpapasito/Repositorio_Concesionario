using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesComprasNegocio
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        DetallesCompras Actualizar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        List<DetallesCompras> Buscar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}