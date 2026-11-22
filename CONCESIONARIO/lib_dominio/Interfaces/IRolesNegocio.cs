using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IRolesNegocio
    {
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        List<Roles> Consultar();
        List<Roles> Buscar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}