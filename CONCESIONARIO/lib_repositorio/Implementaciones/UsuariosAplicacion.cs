using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosNegocio
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Usuarios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IConexion.Usuarios!
                .Where(x => x.NombreUsuario!.Contains(entidad.NombreUsuario!))
                .Where(x => x.Correo!.Contains(entidad.Correo!))
                .ToList();
        }


        public List<Usuarios> Consultar()
        {
            return this.IConexion.Usuarios!
                .Take(5).ToList();
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Usuarios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    
    }
}