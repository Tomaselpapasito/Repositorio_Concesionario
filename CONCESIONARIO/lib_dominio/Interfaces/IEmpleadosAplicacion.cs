using lib_dominio.Entidades;

namespace lib_dominio.Interfaces
{
    public interface IEmpleadosAplicacion
	{
        Empleados Insertar(Empleados entidad, int IdUsuario);
        Empleados Actualizar(Empleados entidad,int  IdUsuario);
        List<Empleados> Consultar();
        List<Empleados> Buscar(Empleados entidad);
        Empleados Borrar(Empleados entidad, int IdUsuario);
    }
}