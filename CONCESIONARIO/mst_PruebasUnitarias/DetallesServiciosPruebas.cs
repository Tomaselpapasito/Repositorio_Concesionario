using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class DetallesServiciosPruebas
    {
        private IConexion conexion;
        private DetallesServicios? entidad = null;

        public DetallesServiciosPruebas()
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
            this.entidad = new DetallesServicios()
            {
                Cantidad = 1,
                Precio = 100.0m,
                Descuento = 10.0m,
                Subtotal = 90.0m,
                Orden = 1,
                Servicio = 1
            };
            this.conexion.DetallesServicios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetallesServicios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 200000;

            var entry = this.conexion!.Entry<DetallesServicios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesServicios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
