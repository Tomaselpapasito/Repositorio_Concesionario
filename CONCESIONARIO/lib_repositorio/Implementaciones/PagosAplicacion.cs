using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class PagosAplicacion : IPagosNegocio
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

            if (entidad.Validar())
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

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}