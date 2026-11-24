using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFinanciamientosPresentacion
    {
        Financiamientos Insertar(Financiamientos entidad);
        Financiamientos Actualizar(Financiamientos entidad);
        List<Financiamientos> Consultar();
        List<Financiamientos> Buscar(Financiamientos entidad);
        Financiamientos Borrar(Financiamientos entidad);
    }
}