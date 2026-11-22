using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IVentasNegocio
    {
        Ventas Insertar(Ventas entidad);
        Ventas Actualizar(Ventas entidad);
        List<Ventas> Consultar();
        List<Ventas> Buscar(Ventas entidad);
        Ventas Borrar(Ventas entidad);
    }
}