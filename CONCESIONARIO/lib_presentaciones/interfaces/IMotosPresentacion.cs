using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IMotosPresentacion
    {
        Motos Insertar(Motos entidad);
        Motos Actualizar(Motos entidad);
        List<Motos> Consultar();
        List<Motos> Buscar(Motos entidad);
        Motos Borrar(Motos entidad);
    }
}