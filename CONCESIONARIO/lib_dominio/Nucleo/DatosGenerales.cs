using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Nucleo
{
    public class DatosGenerales
    {
        public static string ObtenerStringConexion()
        {
            return "server=localhost;database=CONCESIONARIO_DB;Integrated Security=True;TrustServerCertificate=true;";
        }
    }

}

