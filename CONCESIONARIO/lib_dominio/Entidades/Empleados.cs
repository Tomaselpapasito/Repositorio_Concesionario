using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Empleados
    {
        [Key]public int ID { get; set; }
        public string? Carnet { get; set; }
        public DateTime Fecha_Contratacion { get; set; }
        public int Persona { get; set; }
        public int Cargo { get; set; }

        [ForeignKey("Cargo")] public Cargos? _Cargo { get; set; }
        [ForeignKey("Persona")] public Usuarios? _Persona { get; set; }

        public List<Ventas>? Ventas { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(this.Carnet) ||
                this.Fecha_Contratacion == default ||
                this.Persona == 0 ||
                this.Cargo == 0;

        }
    }
}
