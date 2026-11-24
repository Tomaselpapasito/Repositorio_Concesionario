using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
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