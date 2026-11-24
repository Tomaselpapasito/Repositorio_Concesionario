using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IDetallesVentasMotosAplicacion
	{
        DetallesVentasMotos Insertar(DetallesVentasMotos entidad, int IdUsuario);
        DetallesVentasMotos Actualizar(DetallesVentasMotos entidad,int  IdUsuario);
        List<DetallesVentasMotos> Consultar();
        List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad);
        DetallesVentasMotos Borrar(DetallesVentasMotos entidad, int IdUsuario);
    }
}