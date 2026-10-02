using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class ComprasPruebas
    {
        private IConexion conexion;
        private Compras? entidad = null;

        public ComprasPruebas()
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
            this.entidad = new Compras()
            {
                Fecha_Compra = DateTime.Now,
                Impuesto = 2000000.0m,
                Numero_Factura = "123456789",
                Total = 10000000.0m,
                Proveedor = 1
            };
            this.conexion.Compras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Compras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Numero_Factura = "0000000000";

            var entry = this.conexion!.Entry<Compras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Compras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
