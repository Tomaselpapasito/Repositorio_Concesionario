using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IPersonasAplicacion
    {
        Personas Insertar(Personas entidad, int IdUsuario);
        Personas Actualizar(Personas entidad,int  IdUsuario);
        List<Personas> Consultar();
        List<Personas> Buscar(Personas entidad);
        Personas Borrar(Personas entidad, int IdUsuario);
    }
}