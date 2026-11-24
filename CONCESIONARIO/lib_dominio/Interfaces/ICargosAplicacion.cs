using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface ICargosAplicacion
    {
        Cargos Insertar(Cargos entidad, int IdUsuario);
        Cargos Actualizar(Cargos entidad,int  IdUsuario);
        List<Cargos> Consultar();
        List<Cargos> Buscar(Cargos entidad);
        Cargos Borrar(Cargos entidad, int IdUsuario);
    }
}