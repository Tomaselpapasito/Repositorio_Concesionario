using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IOrdenesServiciosAplicacion
    {
        OrdenesServicios Insertar(OrdenesServicios entidad);
        OrdenesServicios Actualizar(OrdenesServicios entidad);
        List<OrdenesServicios> Consultar();
        List<OrdenesServicios> Buscar(OrdenesServicios entidad);
        OrdenesServicios Borrar(OrdenesServicios entidad);
    }
}