using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion IConexion;

        public ProductosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            if (ValidarCodigo(entidad))
                throw new Exception("Ya existe un producto con el mismo código");


            var entry = this.IConexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Productos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            return this.IConexion.Productos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Productos> Consultar()
        {
            return this.IConexion.Productos!
                .Take(5).ToList();
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");
            if (ValidarCodigo(entidad))
                throw new Exception("Ya existe un producto con el mismo código");
            
            this.IConexion.Productos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool ValidarCodigo(Productos entidad)
        {
            return this.IConexion.Productos!.Any(x => x.Codigo == entidad.Codigo);
        }

        private bool BuscarPorId(int id)
        {
            return this.IConexion.Productos!.Any(x => x.ID == id);
        }

        public void ActualizarStock(int id, int cantidad)
        {
            var producto = this.IConexion.Productos!.FirstOrDefault(x => x.ID == id);
            if (!BuscarPorId(id))
                throw new Exception("Producto no encontrado");
            producto!.Stock += cantidad;
            this.IConexion.SaveChanges();

        }
    }
}