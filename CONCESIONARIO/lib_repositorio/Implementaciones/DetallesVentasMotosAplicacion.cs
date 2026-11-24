using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class DetallesVentasMotosAplicacion : IDetallesVentasMotosNegocio
    {
        private IConexion IConexion;

        public DetallesVentasMotosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesVentasMotos Actualizar(DetallesVentasMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesVentasMotos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesVentasMotos Borrar(DetallesVentasMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesVentasMotos!.Remove(entidad!);
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

        public DetallesVentasMotos Insertar(DetallesVentasMotos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesVentasMotos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}