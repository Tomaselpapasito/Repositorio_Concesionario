using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IDetallesComprasPresentacion
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        DetallesCompras Actualizar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        List<DetallesCompras> Buscar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}