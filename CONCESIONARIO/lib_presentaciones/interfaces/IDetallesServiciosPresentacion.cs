using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface IDetallesServiciosPresentacion
    {
        DetallesServicios Insertar(DetallesServicios entidad);
        DetallesServicios Actualizar(DetallesServicios entidad);
        List<DetallesServicios> Consultar();
        List<DetallesServicios> Buscar(DetallesServicios entidad);
        DetallesServicios Borrar(DetallesServicios entidad);
    }
}