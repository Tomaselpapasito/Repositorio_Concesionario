using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion IConexion;

        public PagosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Pagos Actualizar(Pagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Pagos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IConexion.Pagos!
                .Include (x=> x._Venta)
                    .ThenInclude(x => x!._Cliente)
                .Where(x => x._Venta!._Cliente!.Numero_Licencia!.Contains(entidad._Venta!._Cliente!.Numero_Licencia!))
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.IConexion.Pagos!
                .Take(5).ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Pagos entidad)
        {
            return entidad.Monto <= 0 ||
                entidad.Metodo == 0   ||
                entidad.Venta == 0;
         }
    }
}