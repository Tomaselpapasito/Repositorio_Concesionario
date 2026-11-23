using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IProveedoresNegocio
    {
        Proveedores Insertar(Proveedores entidad);
        Proveedores Actualizar(Proveedores entidad);
        List<Proveedores> Consultar();
        List<Proveedores> BuscarPorNombre(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
        Proveedores BuscarPorNIT(Proveedores entidad);
        List<Proveedores> ConsultarProveedoresActivos();
        List<Compras> ConsultarCompras(Proveedores entidad);
    }
}