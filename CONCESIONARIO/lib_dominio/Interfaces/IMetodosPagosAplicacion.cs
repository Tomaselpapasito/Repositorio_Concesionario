using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IMetodosPagosAplicacion
    {
        MetodosPagos Insertar(MetodosPagos entidad);
        MetodosPagos Actualizar(MetodosPagos entidad);
        List<MetodosPagos> Consultar();
        List<MetodosPagos> Buscar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad);
    }
}