using lib_dominio.implementaciones;
using lib_dominio.interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace mst_PruebasUnitarias
{
    [TestClass]
    public class OrdenesServiciosPruebas
    {
        private IConexion conexion;
        private OrdenesServicios? entidad = null;

        public OrdenesServiciosPruebas()
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
            this.entidad = new OrdenesServicios()
            {
                Fecha_Ingreso = DateTime.Now,
                Fecha_Salida = DateTime.Now.AddDays(1),
                Descripcion = "Descripcion Prueba",
                Costo_Total = 1000.0m,
                Cliente = 1,
                Empleado = 1,
                Moto = 2
            };
            this.conexion.OrdenesServicios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.OrdenesServicios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Descripcion = "Descripcion Actualizada";

            var entry = this.conexion!.Entry<OrdenesServicios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.OrdenesServicios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
