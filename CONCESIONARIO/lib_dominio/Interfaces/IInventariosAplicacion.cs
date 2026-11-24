using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IInventariosAplicacion
    {
        Inventarios Insertar(Inventarios entidad, int IdUsuario);
        Inventarios Actualizar(Inventarios entidad,int  IdUsuario);
        List<Inventarios> Consultar();
        List<Inventarios> Buscar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad, int IdUsuario);
    }
}