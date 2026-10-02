using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class EmpleadosPruebas
    {
        private IConexion conexion;
        private Empleados? entidad = null;

        public EmpleadosPruebas()
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
            this.entidad = new Empleados()
            {
                Carnet = "12345678999",
                Fecha_Contratacion = DateTime.Now,
                Persona = 2, //Empleado en script es 2
                Cargo = 1
            };
            this.conexion.Empleados!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Empleados!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Carnet = "0000000000";

            var entry = this.conexion!.Entry<Empleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Empleados!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
