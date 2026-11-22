using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class RepuestosAplicacion : IRepuestosAplicacion
    {
        private IConexion IConexion;

        public RepuestosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Repuestos Actualizar(Repuestos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Repuestos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Repuestos Borrar(Repuestos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Repuestos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Repuestos> Buscar(Repuestos entidad)
        {
            return this.IConexion.Repuestos!
                .Include (x=> x._Producto)
                .Where(x => x.Numero_Parte!.Contains(entidad.Numero_Parte!))
                .ToList();
        }

        public List<Repuestos> Consultar()
        {
            return this.IConexion.Repuestos!
                .Take(5).ToList();
        }

        public Repuestos Insertar(Repuestos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Repuestos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Repuestos entidad)
        {
            return string.IsNullOrEmpty(entidad.Numero_Parte) ||
                   entidad.Producto == 0;
         }
    }
}