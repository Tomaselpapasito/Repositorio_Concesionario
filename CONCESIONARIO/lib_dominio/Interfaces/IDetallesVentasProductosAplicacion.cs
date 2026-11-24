using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesVentasProductosAplicacion
	{
        DetallesVentasProductos Insertar(DetallesVentasProductos entidad, int IdUsuario);
        DetallesVentasProductos Actualizar(DetallesVentasProductos entidad,int  IdUsuario);
        List<DetallesVentasProductos> Consultar();
        List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad);
        DetallesVentasProductos Borrar(DetallesVentasProductos entidad, int IdUsuario);
    }
}