using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Interfaces
{
    public interface IAuditoria
    {
 

            int ID { get; set; }
            int Objeto { get; set; }
            DateTime Fecha { get; set; }
            string? Accion { get; set; }
            string? Detalles { get; set; }
            int Usuario { get; set; }
        }
}
