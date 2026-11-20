using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace lib_dominio.entidades
{
    public class Auditorias
        {
            [Key] public int ID { get; set; }
            public string? Comentarios { get; set; }
            public DateTime Fecha { get; set; }

        }
    }
