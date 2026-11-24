using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class InventariosAplicacion : IInventariosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public InventariosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Inventarios Actualizar(Inventarios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasInventarios>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Ubicacion {entidad.Ubicacion} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasInventarios!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Inventarios Borrar(Inventarios entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Inventarios!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasInventarios>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Ubicacion {entidad.Ubicacion} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasInventarios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Inventarios> Buscar(Inventarios entidad)
        {
            return this.IConexion.Inventarios!
                .Include(x => x._Moto)
                .Where(x => x.Ubicacion!.Contains(entidad.Ubicacion!))
                .ToList();
        }

        public List<Inventarios> Consultar()
        {
            return this.IConexion.Inventarios!
                .Take(5).ToList();
        }

        public Inventarios Insertar(Inventarios entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Inventarios!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasInventarios>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Ubicacion {entidad.Ubicacion} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasInventarios!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}