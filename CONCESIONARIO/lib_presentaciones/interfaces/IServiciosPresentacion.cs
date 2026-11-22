using lib_dominio.entidades;

namespace lib_presentaciones.interfaces
{
    public interface IServiciosPresentacion
    {
        List<Servicios> Consultar();
        List<Servicios> Buscar(Servicios entidad);
    }
}