using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IInventariosPresentacion
    {
        Inventarios Insertar(Inventarios entidad);
        Inventarios Actualizar(Inventarios entidad);
        List<Inventarios> Consultar();
        List<Inventarios> Buscar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad);
    }
}