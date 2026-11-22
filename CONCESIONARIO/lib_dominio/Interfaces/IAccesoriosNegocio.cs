using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IAccesoriosNeogocio
    {
        Accesorios Insertar(Accesorios entidad);
        Accesorios Actualizar(Accesorios entidad);
        List<Accesorios> Consultar();
        List<Accesorios> Buscar(Accesorios entidad);
        Accesorios Borrar(Accesorios entidad);
    }
}