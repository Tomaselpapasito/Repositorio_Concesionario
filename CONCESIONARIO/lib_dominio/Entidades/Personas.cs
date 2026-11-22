using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Personas
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Telefono { get; set; }
    }
}
