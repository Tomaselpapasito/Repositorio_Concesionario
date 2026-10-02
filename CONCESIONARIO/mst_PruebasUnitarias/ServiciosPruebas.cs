using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class ServiciosPruebas
    {
        private IConexion conexion;
        private Servicios? entidad = null;

        public ServiciosPruebas()
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
            this.entidad = new Servicios()
            {
                Nombre = "Prueba",
                Precio = 1000000.0m,
                Duracion = 60,
                Tipo_Servicio = "Prueba Tipo"
            };
            this.conexion.Servicios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Servicios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "0000000000";

            var entry = this.conexion!.Entry<Servicios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Servicios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
