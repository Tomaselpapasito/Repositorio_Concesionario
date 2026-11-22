using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace lib_repositorio.Implementaciones
{
    public class PermisosAplicacion : IPermisosNegocio
    {
        private IConexion IConexion;

        public PermisosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.ID == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Permisos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IConexion.Permisos!
                .Include (X => X._Rol)
                .Where(x => x.Descripcion!.Contains(entidad.Descripcion!))
                .ToList();
        }

        public List<Permisos> Consultar()
        {
            return this.IConexion.Permisos!
                .Take(5).ToList();
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.ID != 0)
                throw new Exception("Ya se guardo");

            if (entidad.Validar())
                throw new Exception("Falta informacion");

            this.IConexion.Permisos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }
    
        private bool Validar(Permisos entidad)
        {
            return string.IsNullOrEmpty(entidad.Descripcion) ||
                entidad.Rol == 0;
         }
    }
}