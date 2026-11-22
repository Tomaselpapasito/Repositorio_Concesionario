using lib_dominio.Entidades;

namespace lib_presentaciones.interfaces
{
    public interface IRepuestosPresentacion
    {
        Repuestos Insertar(Repuestos entidad);
        Repuestos Actualizar(Repuestos entidad);
        List<Repuestos> Consultar();
        List<Repuestos> Buscar(Repuestos entidad);
        Repuestos Borrar(Repuestos entidad);
    }
}