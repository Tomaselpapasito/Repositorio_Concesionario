using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IFinanciamientosAplicacion
    {
        Financiamientos Insertar(Financiamientos entidad, int IdUsuario);
        Financiamientos Actualizar(Financiamientos entidad,int  IdUsuario);
        List<Financiamientos> Consultar();
        List<Financiamientos> Buscar(Financiamientos entidad);
        Financiamientos Borrar(Financiamientos entidad, int IdUsuario);
    }
}