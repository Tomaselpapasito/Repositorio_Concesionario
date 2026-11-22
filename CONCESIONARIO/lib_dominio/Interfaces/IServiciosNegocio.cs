using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IServiciosNegocio
    {
        Servicios Insertar(Servicios entidad);
        Servicios Actualizar(Servicios entidad);
        List<Servicios> Consultar();
        List<Servicios> Buscar(Servicios entidad);
        Servicios Borrar(Servicios entidad);
    }
}