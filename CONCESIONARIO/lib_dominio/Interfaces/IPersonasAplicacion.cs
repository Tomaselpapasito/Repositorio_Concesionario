using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IPersonasAplicacion
    {
        Personas Insertar(Personas entidad);
        Personas Actualizar(Personas entidad);
        List<Personas> Consultar();
        List<Personas> Buscar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}