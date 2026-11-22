using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class ModelosMotosAplicacion : IModelosMotosAplicacion
    {
        private IConexion IConexion;

        public ModelosMotosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public ModelosMotos Actualizar(ModelosMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<ModelosMotos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public ModelosMotos Borrar(ModelosMotos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.ModelosMotos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<ModelosMotos> Buscar(ModelosMotos entidad)
        {
            return this.IConexion.ModelosMotos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<ModelosMotos> Consultar()
        {
            return this.IConexion.ModelosMotos!
                .Take(5).ToList();
        }

        public ModelosMotos Insertar(ModelosMotos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.ModelosMotos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(ModelosMotos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Cilindraje <= 0 ||
                string.IsNullOrEmpty(entidad.Tipo_motor) ||
                string.IsNullOrEmpty(entidad.Transmision) ||
                entidad.Potencia <= 0;
         }
    }
}