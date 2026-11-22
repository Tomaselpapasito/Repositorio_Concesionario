using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorio.Implementaciones
{
    public class DetallesComprasNegocio : IDetallesComprasNegocio
    {
        private IConexion IConexion;

        public DetallesComprasNegocio(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesCompras!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            return this.IConexion.DetallesCompras!
                .Include(x => x._Compra)
                .Include(x => x._Producto)
                .Where(x => x._Producto!.Nombre!.Contains(entidad._Producto!.Nombre!))
                .ToList();
        }

        public List<DetallesCompras> Consultar()
        {
            return this.IConexion.DetallesCompras!
                .Take(5).ToList();
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.DetallesCompras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }


    }
}