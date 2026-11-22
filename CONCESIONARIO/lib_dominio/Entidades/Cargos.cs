using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Cargos
    {
        [Key] public int ID { get; set; }
        public string? Nombre { get; set; }
        public decimal Salario { get; set; }
        public bool Activo { get; set; }

        [NotMapped]public List<Empleados>? Empleados { get; set; }

        public bool Validar( )
        {
            return string.IsNullOrEmpty(this.Nombre) ||
                    this.Salario <= 0;
        }
    }
}
