using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IMetodosPagosAplicacion
    {
        MetodosPagos Insertar(MetodosPagos entidad, int IdUsuario);
        MetodosPagos Actualizar(MetodosPagos entidad,int  IdUsuario);
        List<MetodosPagos> Consultar();
        List<MetodosPagos> Buscar(MetodosPagos entidad);
        MetodosPagos Borrar(MetodosPagos entidad, int IdUsuario);
    }
}