using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IMotosAplicacion
    {
        Motos Insertar(Motos entidad, int IdUsuario);
        Motos Actualizar(Motos entidad,int  IdUsuario);
        List<Motos> Consultar();
        List<Motos> Buscar(Motos entidad);
        Motos Borrar(Motos entidad, int IdUsuario);
    }
}