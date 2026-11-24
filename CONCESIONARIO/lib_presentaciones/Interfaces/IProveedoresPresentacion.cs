using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IProveedoresPresentacion
    {
        Proveedores Insertar(Proveedores entidad);
        Proveedores Actualizar(Proveedores entidad);
        List<Proveedores> Consultar();
        Proveedores Borrar(Proveedores entidad);

    }
}