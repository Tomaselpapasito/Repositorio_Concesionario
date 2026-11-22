using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Clientes
    {
        [Key]public int ID { get; set; }
        public string? Correo { get; set; }
        public string? Numero_Licencia { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; }
        public int Persona { get; set; }

        [ForeignKey("Persona")] public Personas? _Persona { get; set; }

        [NotMapped]public List<Ventas>? Ventas { get; set; }


        public bool Validar( )
        {
            return string.IsNullOrEmpty(this.Correo) ||
                    string.IsNullOrEmpty(this.Numero_Licencia) ||
                    string.IsNullOrEmpty(this.Direccion) ||
                    this.Persona == 0;
        }

    }
}
