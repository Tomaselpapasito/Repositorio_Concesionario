using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Nucleo
{
    public class DatosGenerales
    {
        public static string ObtenerStringConexion()
        {
            return "server=localhost;database=naturaleza_db;Integrated Security=True;TrustServerCertificate=true;";
        }
    }

}

