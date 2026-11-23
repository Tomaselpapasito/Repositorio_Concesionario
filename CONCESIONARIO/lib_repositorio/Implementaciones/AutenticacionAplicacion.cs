using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using lib_repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_repositorio.Implementaciones
{
    public class AutenticacionAplicacion : IAutenticacion
    {
        private IConexion IConexion;
        public AutenticacionAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }
        public Usuarios? IniciarSesion(string usuario,string contrasena)
        {
            return this.IConexion.Usuarios!
                .FirstOrDefault(x =>
                    x.NombreUsuario == usuario &&
                    x.Contraseña == contrasena
                );
        }
    }
}
