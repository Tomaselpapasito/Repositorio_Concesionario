using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class PagosPruebas
    {
        private IConexion conexion;
        private Pagos? entidad = null;

        public PagosPruebas()
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
            this.entidad = new Pagos()
            {
                Fecha_Pago = DateTime.Now,
                Monto = 1000.0m,
                Metodo = 1,
                Venta = 1
            };
            this.conexion.Pagos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pagos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Monto = 2000.0m;

            var entry = this.conexion!.Entry<Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
