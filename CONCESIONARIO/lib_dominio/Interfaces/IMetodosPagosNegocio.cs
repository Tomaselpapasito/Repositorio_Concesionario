using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IMetodosPagosNegocio
    {
        MetodosPagos Insertar(MetodosPagos entidad);
        MetodosPagos Actualizar(MetodosPagos entidad);
        List<MetodosPagos> Consultar();
        List<MetodosPagos> Buscar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad);
    }
}