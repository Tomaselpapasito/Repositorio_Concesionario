using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IClientesAplicacion
    {
        Clientes Insertar(Clientes entidad, int IdUsuario);
        Clientes Actualizar(Clientes entidad,int  IdUsuario);
        List<Clientes> Consultar();
        Clientes Buscar(Clientes entidad);
        Clientes Borrar(Clientes entidad, int IdUsuario);
        Clientes BuscarPorVenta(int compra);

    }
}