using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IPersonasNegocio
    {
        Personas Insertar(Personas entidad);
        Personas Actualizar(Personas entidad);
        List<Personas> Consultar();
        List<Personas> Buscar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}