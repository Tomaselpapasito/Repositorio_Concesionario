using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;
using lib_dominio.Interfaces;
namespace lib_repositorio.Implementaciones
{
    public class CuotasAplicacion : ICuotasNegocio
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

            if (entidad.Validar())
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

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Cuotas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}