using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_dominio.Auditorias
{
    public class AuditoriasFinanciamientos
    {
        [Key] public int ID { get; set; }
        public int Accesorio { get; set; }
        public DateTime Fecha { get; set; }
        public string? Accion { get; set; }
        public string? Detalles { get; set; }

        public int Usuario { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
