using lib_dominio.entidades;

namespace lib_dominio.interfaces
{
    public interface IFinanciamientosAplicacion
    {
        Financiamientos Insertar(Financiamientos entidad);
        Financiamientos Actualizar(Financiamientos entidad);
        List<Financiamientos> Consultar();
        List<Financiamientos> Buscar(Financiamientos entidad);
        Financiamientos Borrar(Financiamientos entidad);
    }
}