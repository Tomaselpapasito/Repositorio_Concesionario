using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class MotosAplicacion : IMotosNegocio
    {
        private IConexion IConexion;

        public MotosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Motos Actualizar(Motos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Motos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Motos Borrar(Motos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Motos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Motos> Buscar(Motos entidad)
        {
            return this.IConexion.Motos!
                .Include (x=> x._Modelo)
                .Where(x => x.VIN!.Contains(entidad.VIN!))
                .ToList();
        }

        public List<Motos> Consultar()
        {
            return this.IConexion.Motos!
                .Take(5).ToList();
        }

        public Motos Insertar(Motos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Motos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

    }
}