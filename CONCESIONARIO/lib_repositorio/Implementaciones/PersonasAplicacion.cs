using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class PersonasAplicacion : IPersonasNegocio
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;

        public PersonasAplicacion(IConexion IConexion,IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;
        }

        public Personas Actualizar(Personas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Personas>(entidad);
            entry.State = EntityState.Modified;
            var audioria = IAuditorias.CrearAuditoria<AuditoriasPersonas>(entidad.ID, "Actualizar", "Se crea actualizo la Persona ----" ,1);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Personas!.Remove(entidad!);
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

        public Personas Insertar(Personas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Personas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    
        private bool Validar(Personas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Cedula) ||
                string.IsNullOrEmpty(entidad.Telefono);
         }
    }
}