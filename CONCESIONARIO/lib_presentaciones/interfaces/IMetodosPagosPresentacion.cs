using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IMetodosPagosPresentacion
    {
        List<MetodosPagos> Consultar();
        List<MetodosPagos> Buscar(MetodosPagos entidad);
    }
}