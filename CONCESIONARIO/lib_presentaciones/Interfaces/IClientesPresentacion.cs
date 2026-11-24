using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesPresentacion
    {
        Clientes Insertar(Clientes entidad);
        Clientes Actualizar(Clientes entidad);
        List<Clientes> Consultar();
        Clientes Buscar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
        Clientes BuscarPorVenta(int compra);

    }
}