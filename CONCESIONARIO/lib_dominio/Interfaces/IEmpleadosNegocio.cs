using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IEmpleadosNegocio
	{
        Empleados Insertar(Empleados entidad);
        Empleados Actualizar(Empleados entidad);
        List<Empleados> Consultar();
        List<Empleados> Buscar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}