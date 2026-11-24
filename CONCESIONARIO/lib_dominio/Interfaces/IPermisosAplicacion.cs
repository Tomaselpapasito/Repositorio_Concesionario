using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IPermisosAplicacion
    {
        Permisos Insertar(Permisos entidad, int IdUsuario);
        Permisos Actualizar(Permisos entidad,int  IdUsuario);
        List<Permisos> Consultar();
        List<Permisos> Buscar(Permisos entidad);
        Permisos Borrar(Permisos entidad, int IdUsuario);
    }
}