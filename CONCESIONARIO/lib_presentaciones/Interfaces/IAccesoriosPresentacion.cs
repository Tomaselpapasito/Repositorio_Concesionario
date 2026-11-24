using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IAccesoriosPresentacion
    {
        Accesorios Insertar(Accesorios entidad);
        Accesorios Actualizar(Accesorios entidad);
        List<Accesorios> Consultar();
        List<Accesorios> Buscar(Accesorios entidad);
        Accesorios Borrar(Accesorios entidad);
        Accesorios BuscarPorProducto(int producto);
        List<Accesorios> ConsultarAccesoriosDisponibles();
        List<Accesorios> ConsultarAccesoriosPorPrecio(decimal precio);
    }
}