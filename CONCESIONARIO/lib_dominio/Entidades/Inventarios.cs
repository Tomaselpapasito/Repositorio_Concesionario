using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Inventarios 
    {
        [Key]public int ID { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public string? Ubicacion { get; set; }
        public int Moto { get; set; }

        [ForeignKey("Moto")] public Motos? _Moto { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(this.Ubicacion) ||
                this.Fecha_Ingreso == default ||
                this.Moto == 0;
        }
    }
}