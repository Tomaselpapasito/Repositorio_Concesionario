using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class DetallesComprasPruebas
    {
        private IConexion conexion;
        private DetallesCompras? entidad = null;

        public DetallesComprasPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();
        }

        [TestMethod]
        public void Ejecutar()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new DetallesCompras()
            {
                Cantidad = 1,
                Precio_Unitario = 100.0m,
                Descuento = 10.0m,
                Subtotal = 90.0m,
                Compra = 1,
                Producto = 2
            };
            this.conexion.DetallesCompras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesCompras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 200000;

            var entry = this.conexion!.Entry<DetallesCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesCompras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
