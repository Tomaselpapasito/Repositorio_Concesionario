using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IDetallesVentasProductosAplicacion
    {
        DetallesVentasProductos Insertar(DetallesVentasProductos entidad);
        DetallesVentasProductos Actualizar(DetallesVentasProductos entidad);
        List<DetallesVentasProductos> Consultar();
        List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad);
        DetallesVentasProductos Borrar(DetallesVentasProductos entidad);
    }
}