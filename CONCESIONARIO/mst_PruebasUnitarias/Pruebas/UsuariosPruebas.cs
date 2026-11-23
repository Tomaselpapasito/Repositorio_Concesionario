using lib_repositorio.Implementaciones;
using lib_dominio.Interfaces;
using lib_dominio.Nucleo;
using Microsoft.EntityFrameworkCore;
using lib_repositorio.Interfaces;
using lib_dominio.Entidades;

namespace mst_PruebasUnitarias.Pruebas
{
    [TestClass]
    public class UsuariosPruebas
    {
        private IConexion conexion;
        private Usuarios? entidad = null;

        public UsuariosPruebas()
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
            this.entidad = new Usuarios()
            {
                NomUsuario = "Prueba",
                Contraseña = "ContraseñaPrueba",
                
            };
            this.conexion.Usuarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Usuarios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NomUsuario = "0000000000";

            var entry = this.conexion!.Entry<Usuarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Usuarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
