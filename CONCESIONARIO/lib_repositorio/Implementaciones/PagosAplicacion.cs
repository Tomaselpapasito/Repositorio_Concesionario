using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public PagosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public Pagos Actualizar(Pagos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPagos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Monto {entidad.Monto} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPagos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Pagos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPagos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Monto {entidad.Monto} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPagos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IConexion.Pagos!
                .Include (x=> x._Venta)
                    .ThenInclude(x => x!._Cliente)
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.IConexion.Pagos!
                .Take(5).ToList();
        }

        public Pagos Insertar(Pagos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasPagos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Monto {entidad.Monto} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasPagos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}