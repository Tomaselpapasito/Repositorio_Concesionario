using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class RepuestosPruebas
    {
        private IConexion conexion;
        private Repuestos? entidad = null;

        public RepuestosPruebas()
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
            this.entidad = new Repuestos()
            {
                Numero_Parte = "RP-001",
                Descripcion = "Repuesto de prueba",
                Fecha_Modificacion = DateTime.Now,
                Producto = 1
            };
            this.conexion.Repuestos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Repuestos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Numero_Parte = "000000000";

            var entry = this.conexion!.Entry<Repuestos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Repuestos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
