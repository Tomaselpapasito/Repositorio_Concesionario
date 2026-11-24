using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class DetallesVentasMotosAplicacion : IDetallesVentasMotosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public DetallesVentasMotosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public DetallesVentasMotos Actualizar(DetallesVentasMotos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesVentasMotos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasMotos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Precio {entidad.Precio_Unitario} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasMotos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesVentasMotos Borrar(DetallesVentasMotos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesVentasMotos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasMotos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Precio {entidad.Precio_Unitario} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesVentasMotos> Buscar(DetallesVentasMotos entidad)
        {
            return this.IConexion.DetallesVentasMotos!
                .Include (x=> x._Venta)
                .Include(x => x._Moto)
                .ToList();
        }

        public List<DetallesVentasMotos> Consultar()
        {
            return this.IConexion.DetallesVentasMotos!
                .Take(5).ToList();
        }

        public DetallesVentasMotos Insertar(DetallesVentasMotos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesVentasMotos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasMotos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Precio {entidad.Precio_Unitario} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasMotos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}