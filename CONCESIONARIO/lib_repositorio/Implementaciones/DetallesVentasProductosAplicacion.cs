using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class DetallesVentasProductosAplicacion : IDetallesVentasProductosAplicacion
    {
        private IConexion IConexion;
        private IAuditorias IAuditorias;
        public DetallesVentasProductosAplicacion (IConexion IConexion, IAuditorias IAuditorias)
        {
            this.IConexion = IConexion;
            this.IAuditorias = IAuditorias;

        }

        public DetallesVentasProductos Actualizar(DetallesVentasProductos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesVentasProductos>(entidad);
            entry.State = EntityState.Modified;
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasProductos>(
                objeto: 1,
                accion: "Actualizar",
                detalles: $"Cantidad {entidad.Cantidad} actualizado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasProductos!.Add(auditoria);
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesVentasProductos Borrar(DetallesVentasProductos entidad, int IdUsuario)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesVentasProductos!.Remove(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasProductos>(
                objeto: 1,
                accion: "Borrar",
                detalles: $"Cantidad {entidad.Cantidad} borrado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasProductos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesVentasProductos> Buscar(DetallesVentasProductos entidad)
        {
            return this.IConexion.DetallesVentasProductos!
                .Include (x => x._Producto)
                .Include (x => x._Venta)
                .ToList();
        }

        public List<DetallesVentasProductos> Consultar()
        {
            return this.IConexion.DetallesVentasProductos!
                .Take(5).ToList();
        }

        public DetallesVentasProductos Insertar(DetallesVentasProductos entidad, int IdUsuario)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesVentasProductos!.Add(entidad!);
            var auditoria = IAuditorias.CrearAuditoria<AuditoriasDetallesVentasProductos>(
                objeto: 1,
                accion: "Insertar",
                detalles: $"Cantidad {entidad.Cantidad} insertado",
                usuario: IdUsuario
            );
            IConexion.AuditoriasDetallesVentasProductos!.Add(auditoria);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}