using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

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
                .Include(x => x._Empleado)
                .Include(x => x._Cliente)
                .ToList();
        }

        public List<Ventas> Consultar()
        {
            return this.IConexion.Ventas!
                .OrderByDescending(x => x.Fecha_Venta)
                .ToList();
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

    }
}