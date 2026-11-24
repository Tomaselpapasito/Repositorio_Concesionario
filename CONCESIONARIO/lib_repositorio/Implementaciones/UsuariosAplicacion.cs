using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public UsuariosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }
        public Usuarios Actualizar(Usuarios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;

            var auditoria = IAuditorias.CrearAuditoria<AuditoriasUsuarios>(
               objeto: 1,
               accion: "Actualizar",
               detalles: $"Nombre {entidad.NombreUsuario} actualizado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasUsuarios!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Usuarios!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasUsuarios>(
               objeto: 1,
               accion: "Borrar",
               detalles: $"Nombre {entidad.NombreUsuario} borrado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasUsuarios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

         public List<Usuarios> Buscar(Usuarios entidad)
         {
             return this.IConexion.Usuarios!
                 .Where(x => x.NombreUsuario!.Contains(entidad.NombreUsuario!))
                 .ToList();
         }
        

        public List<Usuarios> Consultar()
        {
            return this.IConexion.Usuarios!
                .Take(5).ToList();
        }

        public Usuarios Insertar(Usuarios entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Usuarios!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasUsuarios>(
               objeto: 1,
               accion: "Insertar",
               detalles: $"Nombre {entidad.NombreUsuario} insertado",
               usuario: IdUsuario
           );
            IConexion.AuditoriasUsuarios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }
    
    }
}