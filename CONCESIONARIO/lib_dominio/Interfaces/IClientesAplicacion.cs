using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IClientesAplicacion
    {
        Clientes Insertar(Clientes entidad);
        Clientes Actualizar(Clientes entidad);
        List<Clientes> Consultar();
        List<Clientes> Buscar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}