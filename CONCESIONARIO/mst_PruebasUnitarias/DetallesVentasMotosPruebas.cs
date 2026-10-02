using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class DetallesVentasMotosPruebas
    {
        private IConexion conexion;
        private DetallesVentasMotos? entidad = null;

        public DetallesVentasMotosPruebas()
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
            this.entidad = new DetallesVentasMotos()
            {
                Precio_Unitario = 10000.0m,
                Descuento = 200.0m,
                Subtotal = 10000.0m - 200.0m,
                Moto = 1,
                Venta = 1
            };
            this.conexion.DetallesVentasMotos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesVentasMotos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio_Unitario = 20000000000000.0m;

            var entry = this.conexion!.Entry<DetallesVentasMotos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesVentasMotos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
