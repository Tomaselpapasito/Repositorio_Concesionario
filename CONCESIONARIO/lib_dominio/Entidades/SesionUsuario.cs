using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Entidades
{
    public class SesionUsuario
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; } = "";
        public string Token { get; set; } = "";
    }
}
