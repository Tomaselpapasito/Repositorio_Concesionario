using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IPagosAplicacion
    {
        Pagos Insertar(Pagos entidad, int IdUsuario);
        Pagos Actualizar(Pagos entidad,int  IdUsuario);
        List<Pagos> Consultar();
        List<Pagos> Buscar(Pagos entidad);
        Pagos Borrar(Pagos entidad, int IdUsuario);
    }
}