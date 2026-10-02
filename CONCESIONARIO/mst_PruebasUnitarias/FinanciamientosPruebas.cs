using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class FinanciamientosPruebas
    {
        private IConexion conexion;
        private Financiamientos? entidad = null;

        public FinanciamientosPruebas()
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
            this.entidad = new Financiamientos()
            {
                Monto = 2000.0m,
                Numero_Cuotas = 12,
                Tasa_Interes = 5.0m,
                Fecha_Inicio = DateTime.Now,
                Fecha_Fin = DateTime.Now.AddMonths(12),
                Estado = "Activo",
                Venta = 1
            };
            this.conexion.Financiamientos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Financiamientos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Monto = 3000.0m;

            var entry = this.conexion!.Entry<Financiamientos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Financiamientos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
