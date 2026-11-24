using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class DetallesVentasProductosAplicacion : IDetallesVentasProductosAplicacion
    {
        private IConexion IConexion;

        public DetallesVentasProductosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesVentasProductos Actualizar(DetallesVentasProductos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesVentasProductos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesVentasProductos Borrar(DetallesVentasProductos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesVentasProductos!.Remove(entidad!);
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

        public DetallesVentasProductos Insertar(DetallesVentasProductos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesVentasProductos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}