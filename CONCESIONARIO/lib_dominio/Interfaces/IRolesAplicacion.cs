using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IRolesAplicacion
    {
        Roles Insertar(Roles entidad, int IdUsuario);
        Roles Actualizar(Roles entidad,int  IdUsuario);
        List<Roles> Consultar();
        List<Roles> Buscar(Roles entidad);
        Roles Borrar(Roles entidad, int IdUsuario);
    }
}