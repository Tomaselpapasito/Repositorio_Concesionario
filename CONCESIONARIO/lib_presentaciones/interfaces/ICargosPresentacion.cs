using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface ICargosPresentacion
    {
        List<Cargos> Consultar();
        List<Cargos> Buscar(Cargos entidad);
    }
}