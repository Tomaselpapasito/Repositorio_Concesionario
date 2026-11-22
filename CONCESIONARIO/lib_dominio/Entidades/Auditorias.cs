using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int ID { get; set; }
        public int Usuario { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(this.Descripcion) ||
                this.Usuario == 0;
        }
    }
}
