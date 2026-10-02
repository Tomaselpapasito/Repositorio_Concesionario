using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class PersonasPruebas
    {
        private IConexion conexion;
        private Personas? entidad = null;

        public PersonasPruebas()
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
            this.entidad = new Personas()
            {
                Nombre = "Arnold",
                Cedula = "123456789",
                Fecha_Nacimiento = new DateTime(1990, 1, 1),
                Telefono = "987654321"
            };
            this.conexion.Personas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Personas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "0000000000";

            var entry = this.conexion!.Entry<Personas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Personas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

