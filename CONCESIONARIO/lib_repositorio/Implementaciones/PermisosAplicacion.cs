using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lib_repositorio.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public PermisosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Permisos Actualizar(Permisos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPermisos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Descripcion {entidad.Descripcion} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPermisos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Permisos Borrar(Permisos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Permisos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPermisos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Descripcion {entidad.Descripcion} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPermisos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IConexion.Permisos!
                .Include (X => X._Rol)
                .Where(x => x.Descripcion!.Contains(entidad.Descripcion!))
                .ToList();
        }

        public List<Permisos> Consultar()
        {
            return this.IConexion.Permisos!
                .Take(5).ToList();
        }

        public Permisos Insertar(Permisos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Permisos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPermisos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Descripcion {entidad.Descripcion} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPermisos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}