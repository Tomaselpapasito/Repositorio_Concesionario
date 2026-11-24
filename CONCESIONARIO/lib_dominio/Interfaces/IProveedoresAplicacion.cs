using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IProveedoresAplicacion
    {
        Proveedores Insertar(Proveedores entidad, int IdUsuario);
        Proveedores Actualizar(Proveedores entidad,int  IdUsuario);
        List<Proveedores> Consultar();
        List<Proveedores> BuscarPorNombre(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad, int IdUsuario);
        Proveedores BuscarPorNIT(Proveedores entidad);
        List<Proveedores> ConsultarProveedoresActivos();
        List<Compras> ConsultarCompras(Proveedores entidad);
    }
}