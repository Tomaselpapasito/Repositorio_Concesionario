using lib_dominio.entidades;
using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_dominio.implementaciones
{
    public class DetallesComprasAplicacion : IDetallesComprasAplicacion
    {
        private IConexion IConexion;

        public DetallesComprasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
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

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesCompras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesCompras entidad)
        {
            return entidad.Cantidad <= 0 ||
                entidad.Precio_Unitario <= 0 ||
                entidad.Descuento < 0 ||
                entidad.Subtotal <= 0 ||
                entidad.Compra == 0 ||
                entidad.Producto == 0;


           }
    }
}