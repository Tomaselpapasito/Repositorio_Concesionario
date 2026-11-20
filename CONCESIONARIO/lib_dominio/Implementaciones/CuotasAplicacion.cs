using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class CuotasAplicacion : ICuotasAplicacion
    {
        private IConexion IConexion;

        public CuotasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Cuotas Actualizar(Cuotas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cuotas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cuotas Borrar(Cuotas entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cuotas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cuotas> Buscar(Cuotas entidad)
        {
            return this.IConexion.Cuotas!
                .Include (x=> x._Financiamiento)
                    .ThenInclude (x => x!._Venta)
                        .ThenInclude(x => x!._Cliente)
                .Where(x => x._Financiamiento!._Venta!._Cliente!.Numero_Licencia!.Contains(entidad._Financiamiento!._Venta!._Cliente!.Numero_Licencia!))
                .ToList();
        }

        public List<Cuotas> Consultar()
        {
            return this.IConexion.Cuotas!
                .Take(5).ToList();
        }

        public Cuotas Insertar(Cuotas entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Cuotas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Cuotas entidad)
        {
            return entidad.Numero_cuota <= 0 ||
                entidad.Monto <= 0 ||
                entidad.Financiamiento == 0;
         }
    }
}