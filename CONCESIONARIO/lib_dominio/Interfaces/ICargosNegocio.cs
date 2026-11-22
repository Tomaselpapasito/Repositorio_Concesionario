using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface ICargosNegocio
    {
        Cargos Insertar(Cargos entidad);
        Cargos Actualizar(Cargos entidad);
        List<Cargos> Consultar();
        List<Cargos> Buscar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}