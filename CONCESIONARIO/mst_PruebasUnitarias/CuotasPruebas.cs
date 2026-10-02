using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class CuotasPruebas
    {
        private IConexion conexion;
        private Cuotas? entidad = null;

        public CuotasPruebas()
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
            this.entidad = new Cuotas()
            {
                Numero_cuota = 1,
                Monto = 5000.0m,
                Fecha_vencimiento = DateTime.Now.AddMonths(1),
                Fecha_pago = DateTime.Now,
                Financiamiento = 1
            };
            this.conexion.Cuotas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Cuotas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Monto = 3000.0m;

            var entry = this.conexion!.Entry<Cuotas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Cuotas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
