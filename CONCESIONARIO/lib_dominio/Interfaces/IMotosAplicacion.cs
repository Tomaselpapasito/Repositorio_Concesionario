using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IMotosAplicacion
    {
        Motos Insertar(Motos entidad);
        Motos Actualizar(Motos entidad);
        List<Motos> Consultar();
        List<Motos> Buscar(Motos entidad);
        Motos Borrar(Motos entidad);
    }
}