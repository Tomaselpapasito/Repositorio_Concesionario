using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface ICuotasAplicacion
    {
        Cuotas Insertar(Cuotas entidad, int IdUsuario);
        Cuotas Actualizar(Cuotas entidad,int  IdUsuario);
        List<Cuotas> Consultar();
        List<Cuotas> Buscar(Cuotas entidad);
        Cuotas Borrar(Cuotas entidad, int IdUsuario);
    }
}