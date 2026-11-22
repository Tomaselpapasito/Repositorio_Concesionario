using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface IAccesoriosPresentacion
    {
        Accesorios Insertar(Accesorios entidad);
        Accesorios Actualizar(Accesorios entidad);
        List<Accesorios> Consultar();
        List<Accesorios> Buscar(Accesorios entidad);
        Accesorios Borrar(Accesorios entidad);
    }
}