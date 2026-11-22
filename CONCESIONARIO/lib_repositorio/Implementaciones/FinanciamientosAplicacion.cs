using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class FinanciamientosAplicacion : IFinanciamientosNegocio
    {
        private IConexion IConexion;

        public FinanciamientosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Financiamientos Actualizar(Financiamientos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Financiamientos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Financiamientos Borrar(Financiamientos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Financiamientos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Financiamientos> Buscar(Financiamientos entidad)
        {
            return this.IConexion.Financiamientos!
                .Include (x=> x._Venta)
                    .ThenInclude (x => x!._Cliente)
                .Where(x => x._Venta!._Cliente!.Numero_Licencia!.Contains(entidad._Venta!._Cliente!.Numero_Licencia!))
                .ToList();
        }

        public List<Financiamientos> Consultar()
        {
            return this.IConexion.Financiamientos!
                .Take(5).ToList();
        }

        public Financiamientos Insertar(Financiamientos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Financiamientos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Financiamientos entidad)
        {
            return 
                entidad.Monto < 0           ||
                entidad.Numero_Cuotas <= 0  ||
                entidad.Tasa_Interes < 0    ||
                entidad.Venta == 0;
         }
    }
}