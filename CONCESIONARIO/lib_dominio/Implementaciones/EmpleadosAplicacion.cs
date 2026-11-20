using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion IConexion;

        public EmpleadosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Empleados!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Buscar(Empleados entidad)
        {
            return this.IConexion.Empleados!
                .Include (x=> x._Persona)
                .Include(x => x._Cargo)
                .Where(x => x.Carnet!.Contains(entidad.Carnet!))
                .ToList();
        }

        public List<Empleados> Consultar()
        {
            return this.IConexion.Empleados!
                .Take(5).ToList();
        }

        public Empleados Insertar(Empleados entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Empleados!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Empleados entidad)
        {
            return string.IsNullOrEmpty(entidad.Carnet) ||
                entidad.Fecha_Contratacion == default ||
                entidad.Persona == 0 ||
                entidad.Persona == 0;

        }
    }
}