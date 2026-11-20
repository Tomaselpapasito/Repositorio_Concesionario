using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IRepuestosAplicacion
    {
        Repuestos Insertar(Repuestos entidad);
        Repuestos Actualizar(Repuestos entidad);
        List<Repuestos> Consultar();
        List<Repuestos> Buscar(Repuestos entidad);
        Repuestos Borrar(Repuestos entidad);
    }
}