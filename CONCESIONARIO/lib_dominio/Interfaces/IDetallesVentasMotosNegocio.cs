using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesVentasMotosNegocio
	{
        DetallesVentasMotos Insertar(DetallesVentasMotos entidad);
        DetallesVentasMotos Actualizar(DetallesVentasMotos entidad);
        List<DetallesVentasMotos> Consultar();
        List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad);
        DetallesVentasMotos Borrar(DetallesVentasMotos entidad);
    }
}