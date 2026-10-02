using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class ModelosMotosPruebas
    {
        private IConexion conexion;
        private ModelosMotos? entidad = null;

        public ModelosMotosPruebas()
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
            this.entidad = new ModelosMotos()
            {
                Nombre = "Prueba",
                Cilindraje = 200,
                Tipo_motor = "Prueba Motor",
                Transmision = "Prueba Transmision",
                Potencia = 100.0m
            };
            this.conexion.ModelosMotos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ModelosMotos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "0000000000";

            var entry = this.conexion!.Entry<ModelosMotos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ModelosMotos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
