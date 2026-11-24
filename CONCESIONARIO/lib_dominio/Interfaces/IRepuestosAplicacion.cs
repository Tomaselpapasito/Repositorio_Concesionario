using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IRepuestosAplicacion
    {
        Repuestos Insertar(Repuestos entidad, int IdUsuario);
        Repuestos Actualizar(Repuestos entidad,int  IdUsuario);
        List<Repuestos> Consultar();
        List<Repuestos> Buscar(Repuestos entidad);
        Repuestos Borrar(Repuestos entidad, int IdUsuario);
    }
}