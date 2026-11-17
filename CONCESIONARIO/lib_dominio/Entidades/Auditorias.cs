using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Comentarios { get; set; }
        public DateTime Fecha { get; set; }
    }
}
