using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion IConexion;

        public VentasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Ventas Actualizar(Ventas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Ventas Borrar(Ventas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Ventas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Buscar(Ventas entidad)
        {
            return this.IConexion.Ventas!
                .Include (x=> x._Empleado)
                .Include(x => x._Cliente)
                .Where(x => x._Cliente!.Numero_Licencia!.Contains(entidad._Cliente!.Numero_Licencia!))
                .ToList();
        }

        public List<Ventas> Consultar()
        {
            return this.IConexion.Ventas!
                .Take(5).ToList();
        }

        public Ventas Insertar(Ventas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Ventas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Ventas entidad)
        {
            return 
                entidad.Fecha_Venta == default ||
                entidad.Impuestos <= 0  ||
                entidad.Total < 0       ||
                entidad.Cliente == 0    ||
                entidad.Cliente == 0;
         }
    }
}