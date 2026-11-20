using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion IConexion;

        public CargosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cargos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.IConexion.Cargos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Cargos> Consultar()
        {
            return this.IConexion.Cargos!
                .Take(5).ToList();
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Cargos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Cargos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                    entidad.Salario <= 0;
         }
    }
}