using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface ICargosPresentacion
    {
        List<Cargos> Consultar();
        List<Cargos> Buscar(Cargos entidad);
    }
}