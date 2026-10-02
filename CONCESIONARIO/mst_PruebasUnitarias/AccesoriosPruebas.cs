using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class AccesoriosPruebas
    {
        private IConexion conexion;
        private Accesorios? entidad = null;

        public AccesoriosPruebas()
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
            this.entidad = new Accesorios()
            {
                Nombre = "Prueba",
                Categoria = "Categoria Prueba",
                Marca = "Marca Prueba",
                Producto = 2
            };
            this.conexion.Accesorios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Accesorios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "0000000000";

            var entry = this.conexion!.Entry<Accesorios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Accesorios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
