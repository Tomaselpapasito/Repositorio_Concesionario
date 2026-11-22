using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface ICuotasNegocio
    {
        Cuotas Insertar(Cuotas entidad);
        Cuotas Actualizar(Cuotas entidad);
        List<Cuotas> Consultar();
        List<Cuotas> Buscar(Cuotas entidad);
        Cuotas Borrar(Cuotas entidad);
    }
}