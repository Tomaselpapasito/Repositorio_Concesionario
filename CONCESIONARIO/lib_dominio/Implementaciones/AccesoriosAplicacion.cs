using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class AccesoriosAplicacion : IAccesoriosAplicacion
    {
        private IConexion IConexion;

        public AccesoriosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Accesorios Actualizar(Accesorios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Accesorios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Accesorios Borrar(Accesorios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Accesorios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Accesorios> Buscar(Accesorios entidad)
        {
            return this.IConexion.Accesorios!
                .Include (x=> x._Producto)
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Accesorios> Consultar()
        {
            return this.IConexion.Accesorios!
                .Take(5).ToList();
        }

        public Accesorios Insertar(Accesorios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Accesorios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Accesorios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Categoria) ||
                string.IsNullOrEmpty(entidad.Marca) ||
                entidad.Producto == 0;
         }
    }
}