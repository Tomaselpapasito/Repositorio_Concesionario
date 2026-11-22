using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface IDetallesVentasMotosPresentacion
    {
        DetallesVentasMotos Insertar(DetallesVentasMotos entidad);
        DetallesVentasMotos Actualizar(DetallesVentasMotos entidad);
        List<DetallesVentasMotos> Consultar();
        List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad);
        DetallesVentasMotos Borrar(DetallesVentasMotos entidad);
    }
}