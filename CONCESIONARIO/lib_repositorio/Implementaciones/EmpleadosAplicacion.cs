using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public EmpleadosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Empleados Actualizar(Empleados entidad , int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasEmpleados>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Carnet {entidad.Carnet} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasEmpleados!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Empleados!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasEmpleados>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Carnet {entidad.Carnet} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasEmpleados!.Add(auditoria);
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

        public Empleados Insertar(Empleados entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Empleados!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasEmpleados>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Carnet {entidad.Carnet} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasEmpleados!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}