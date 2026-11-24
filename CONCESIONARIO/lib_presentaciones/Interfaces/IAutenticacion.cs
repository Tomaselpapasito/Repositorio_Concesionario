using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_presentaciones.Interfaces
{
    public interface IAutenticacion
    {
        Usuarios IniciarSesion(string Usuario, string Contrasena);
    }
}
