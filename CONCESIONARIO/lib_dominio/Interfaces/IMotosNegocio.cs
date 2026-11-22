using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IMotosNegocio
    {
        Motos Insertar(Motos entidad);
        Motos Actualizar(Motos entidad);
        List<Motos> Consultar();
        List<Motos> Buscar(Motos entidad);
        Motos Borrar(Motos entidad);
    }
}