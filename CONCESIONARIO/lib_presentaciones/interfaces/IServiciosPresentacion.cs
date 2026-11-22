using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IServiciosPresentacion
    {
        List<Servicios> Consultar();
        List<Servicios> Buscar(Servicios entidad);
    }
}