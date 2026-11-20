using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IServiciosAplicacion
    {
        Servicios Insertar(Servicios entidad);
        Servicios Actualizar(Servicios entidad);
        List<Servicios> Consultar();
        List<Servicios> Buscar(Servicios entidad);
        Servicios Borrar(Servicios entidad);
    }
}