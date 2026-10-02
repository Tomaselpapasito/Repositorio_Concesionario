using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class DetallesVentasProductosPruebas
    {
        private IConexion conexion;
        private DetallesVentasProductos? entidad = null;

        public DetallesVentasProductosPruebas()
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
            this.entidad = new DetallesVentasProductos()
            {
                Precio_Unitario = 10000.0m,
                Descuento = 200.0m,
                Subtotal = 10000.0m - 200.0m,
                Cantidad = 1,
                Producto = 1,
                Venta = 1
            };
            this.conexion.DetallesVentasProductos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesVentasProductos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio_Unitario = 20000000000000.0m;

            var entry = this.conexion!.Entry<DetallesVentasProductos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesVentasProductos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
