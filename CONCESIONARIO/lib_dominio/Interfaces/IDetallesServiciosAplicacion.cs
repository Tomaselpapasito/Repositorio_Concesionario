using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IDetallesServiciosAplicacion
    {
        DetallesServicios Insertar(DetallesServicios entidad);
        DetallesServicios Actualizar(DetallesServicios entidad);
        List<DetallesServicios> Consultar();
        List<DetallesServicios> Buscar(DetallesServicios entidad);
        DetallesServicios Borrar(DetallesServicios entidad);
    }
}