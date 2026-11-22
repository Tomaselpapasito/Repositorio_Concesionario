using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IUsuariosNegocio
    {
        Usuarios Insertar(Usuarios entidad);
        Usuarios Actualizar(Usuarios entidad);
        List<Usuarios> Consultar();
        List<Usuarios> Buscar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
    }
}