using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Motos
    {
        [Key] public int ID { get; set; }
        public string? VIN { get; set; }
        public string? Numero_Motor { get; set; }
        public string? Color { get; set; }
        public int Anio { get; set; }
        public int Modelo { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("Modelo")] public ModelosMotos? _Modelo { get; set; }

    }
}
