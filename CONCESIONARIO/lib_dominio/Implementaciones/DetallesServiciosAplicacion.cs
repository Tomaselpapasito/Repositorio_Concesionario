using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_dominio.implementaciones
{
    public class DetallesServiciosAplicacion : IDetallesServiciosAplicacion
    {
        private IConexion IConexion;

        public DetallesServiciosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesServicios Actualizar(DetallesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesServicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesServicios Borrar(DetallesServicios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesServicios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesServicios> Buscar(DetallesServicios entidad)
        {
            return this.IConexion.DetallesServicios!
                .Include(x => x._Servicio)
                .Include(x => x._Orden)
                .Where(x => x._Servicio!.Nombre!.Contains(entidad._Servicio!.Nombre!))
                .ToList();
        }

        public List<DetallesServicios> Consultar()
        {
            return this.IConexion.DetallesServicios!
                .Take(5).ToList();
        }

        public DetallesServicios Insertar(DetallesServicios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesServicios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesServicios entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Precio <= 0 ||
                entidad.Descuento <= 0 ||
                entidad.Subtotal <= 0 ||
                entidad.Orden == 0 ||
                entidad.Servicio == 0;
        }
    }
}