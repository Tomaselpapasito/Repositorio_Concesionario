using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lib_repositorio.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion IConexion;

        public RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Roles!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.IConexion.Roles!
                .Include (X => X._Usuario)
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.IConexion.Roles!
                .Take(5).ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Roles!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    
        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Usuario == 0;
         }
    }
}