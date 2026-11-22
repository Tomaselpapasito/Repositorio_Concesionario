using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IOrdenesServiciosPresentacion
    {
        OrdenesServicios Insertar(OrdenesServicios entidad);
        OrdenesServicios Actualizar(OrdenesServicios entidad);
        List<OrdenesServicios> Consultar();
        List<OrdenesServicios> Buscar(OrdenesServicios entidad);
        OrdenesServicios Borrar(OrdenesServicios entidad);
    }
}