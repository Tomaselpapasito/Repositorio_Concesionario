using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class MetodosPagosAplicacion : IMetodosPagosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public MetodosPagosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public MetodosPagos Actualizar(MetodosPagos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<MetodosPagos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMetodosPagos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Nombre {entidad.Nombre} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasMetodosPagos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public MetodosPagos Borrar(MetodosPagos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.MetodosPagos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMetodosPagos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Nombre {entidad.Nombre} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasMetodosPagos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<MetodosPagos> Buscar(MetodosPagos entidad)
        {
            return this.IConexion.MetodosPagos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<MetodosPagos> Consultar()
        {
            return this.IConexion.MetodosPagos!
                .Take(5).ToList();
        }

        public MetodosPagos Insertar(MetodosPagos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.MetodosPagos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasMetodosPagos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Nombre {entidad.Nombre} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasMetodosPagos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}