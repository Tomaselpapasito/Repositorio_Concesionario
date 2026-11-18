using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        [Key]public int ID { get; set; }
        public string? Comentarios { get; set; }
        public DateTime Fecha { get; set; }

    }
}
