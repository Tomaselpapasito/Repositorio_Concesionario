
using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;

namespace lib_repositorio.Implementaciones
{
    public class AutenticacionAplicacion : IAutenticacion
    {
        private IConexion IConexion;

        public AutenticacionAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios? IniciarSesion(string usuario, string contrasena)
        {
            var entidad = this.IConexion.Usuarios!
                .FirstOrDefault(x =>
                    x.NombreUsuario == usuario &&
                    x.Contraseña == contrasena
                );

            if (entidad == null)
                return null;

            // Consultar los roles del usuario
            entidad.Roles = this.IConexion.Roles!
                .Where(x => x.Usuario == entidad.ID)
                .ToList();

            // Consultar los permisos de cada rol
            foreach (var rol in entidad.Roles)
            {
                rol.Permisos = this.IConexion.Permisos!
                    .Where(x => x.Rol == rol.ID)
                    .ToList();
            }

            return entidad;
        }
    }
}
