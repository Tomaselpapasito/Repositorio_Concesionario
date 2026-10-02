using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class MotosPruebas
    {
        private IConexion conexion;
        private Motos? entidad = null;

        public MotosPruebas()
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
            this.entidad = new Motos()
            {
                VIN = "Prueba",
                Numero_Motor = "123456789",
                Color = "Rojo",
                Anio = 2020,
                Estado = "Nuevo",
                Modelo = 1
            };
            this.conexion.Motos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Motos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.VIN = "0000000000";

            var entry = this.conexion!.Entry<Motos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Motos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
