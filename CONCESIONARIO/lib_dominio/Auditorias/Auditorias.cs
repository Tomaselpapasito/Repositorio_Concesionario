using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using lib_dominio.Interfaces;
namespace lib_dominio.Auditorias
{
    [NotMapped]public class Auditorias : IAuditoria
    {
        public int ID { get; set; }

        public int Tabla { get; set; }
        public DateTime Fecha { get; set; }
        public string? Accion { get; set; }
        public string? Detalles { get; set; }
        public int Usuario { get; set; }
    }
}
