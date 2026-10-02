using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class VentasPruebas
    {
        private IConexion conexion;
        private Ventas? entidad = null;

        public VentasPruebas()
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
            this.entidad = new Ventas()
            {
                Fecha_Venta = DateTime.Now,
                Impuestos = 1000.0m,
                Total = 5000.0m,
                Cliente = 1,
                Empleado = 1
            };
            this.conexion.Ventas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Ventas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Impuestos = 2000000000.0m;

            var entry = this.conexion!.Entry<Ventas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Ventas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
