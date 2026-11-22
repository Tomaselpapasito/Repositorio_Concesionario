using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class ModelosMotos
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public int Cilindraje { get; set; }
        public string? Tipo_motor { get; set; }
        public string? Transmision { get; set; }
        public decimal Potencia { get; set; }

        [NotMapped]public List<Motos>? Motos { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(this.Nombre) ||
                this.Cilindraje <= 0 ||
                string.IsNullOrEmpty(this.Tipo_motor) ||
                string.IsNullOrEmpty(this.Transmision) ||
                this.Potencia <= 0;
        }
    }

}