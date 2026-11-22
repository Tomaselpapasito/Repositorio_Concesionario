using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class MetodosPagosAplicacion : IMetodosPagosAplicacion
    {
        private IConexion IConexion;

        public MetodosPagosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public MetodosPagos Actualizar(MetodosPagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<MetodosPagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.MetodosPagos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<MetodosPagos> Buscar(MetodosPagos entidad)
        {
            return this.IConexion.MetodosPagos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<MetodosPagos> Consultar()
        {
            return this.IConexion.MetodosPagos!
                .Take(5).ToList();
        }

        public MetodosPagos Insertar(MetodosPagos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.MetodosPagos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(MetodosPagos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Tipo) ||
                string.IsNullOrEmpty(entidad.Descripcion);
         }
    }
}