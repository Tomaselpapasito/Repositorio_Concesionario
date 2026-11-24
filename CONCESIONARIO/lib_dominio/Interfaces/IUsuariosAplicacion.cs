using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IUsuariosAplicacion
    {
        Usuarios Insertar(Usuarios entidad, int IdUsuario);
        Usuarios Actualizar(Usuarios entidad,int  IdUsuario);
        List<Usuarios> Consultar();
        List<Usuarios> Buscar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad, int IdUsuario);
    }
}