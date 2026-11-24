using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IVentasAplicacion
    {
        Ventas Insertar(Ventas entidad, int IdUsuario);
        Ventas Actualizar(Ventas entidad,int  IdUsuario);
        List<Ventas> Consultar();
        List<Ventas> Buscar(Ventas entidad);
        Ventas Borrar(Ventas entidad, int IdUsuario);
    }
}