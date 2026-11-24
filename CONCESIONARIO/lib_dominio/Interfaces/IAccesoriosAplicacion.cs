using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IAccesoriosAplicacion
    {
        Accesorios Insertar(Accesorios entidad, int IdUsuario);
        Accesorios Actualizar(Accesorios entidad, int IdUsuario);
        List<Accesorios> Consultar();
        List<Accesorios> Buscar(Accesorios entidad);
        Accesorios Borrar(Accesorios entidad, int IdUsuario);
        Accesorios BuscarPorProducto(int producto);
        List<Accesorios> ConsultarAccesoriosDisponibles();
        List<Accesorios> ConsultarAccesoriosPorPrecio(decimal precio);
    }
}