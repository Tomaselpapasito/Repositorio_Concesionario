using lib_dominio.Entidades;
using lib_dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_dominio.Auditorias
{
    public class AuditoriasDetallesVentasMotos : IAuditoria
    {
        [Key] public int ID { get; set; }
        public int Objeto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Accion { get; set; }
        public string? Detalles { get; set; }

        public int Usuario { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
