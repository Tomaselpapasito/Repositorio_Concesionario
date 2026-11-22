using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IFinanciamientosNegocio
    {
        Financiamientos Insertar(Financiamientos entidad);
        Financiamientos Actualizar(Financiamientos entidad);
        List<Financiamientos> Consultar();
        List<Financiamientos> Buscar(Financiamientos entidad);
        Financiamientos Borrar(Financiamientos entidad);
    }
}