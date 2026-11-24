using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;

        public PersonasAplicacion(IConexion IConexion,IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;
        }

        public Personas Actualizar(Personas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            if(ValidarCedula(entidad))
                throw new Exception("Ya hay una persona regisrada con este documento");

            var entry = this.IConexion!.Entry<Personas>(entidad);
            entry.State = EntityState.Modified; 
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPersonas>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cedula {entidad.Cedula} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPersonas!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Personas Borrar(Personas entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Personas!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPersonas>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cedula {entidad.Cedula} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPersonas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Personas> Buscar(Personas entidad)
        {
            return this.IConexion.Personas!
                .Where(x => x.Cedula!.Contains(entidad.Cedula!))
                .ToList();
        }

        public List<Personas> Consultar()
        {
            return this.IConexion.Personas!
                .Take(5).ToList();
        }

        public Personas Insertar(Personas entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");
            if (entidad.Validar())
                throw new Exception("Falta informacion");

            if (ValidarCedula(entidad))
                throw new Exception("Ya hay una persona regisrada con este documento");


            this.IConexion.Personas!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPersonas>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cedula {entidad.Cedula} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPersonas!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }




        private bool ValidarCedula(Personas entidad)
        {
            if(IConexion.Personas!.Any(x => x.Cedula == entidad.Cedula))
                return true;
            return false;
        }
    }
}