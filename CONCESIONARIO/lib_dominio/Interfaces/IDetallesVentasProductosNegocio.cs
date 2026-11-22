using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesVentasProductosNegocio
	{
        DetallesVentasProductos Insertar(DetallesVentasProductos entidad);
        DetallesVentasProductos Actualizar(DetallesVentasProductos entidad);
        List<DetallesVentasProductos> Consultar();
        List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad);
        DetallesVentasProductos Borrar(DetallesVentasProductos entidad);
    }
}