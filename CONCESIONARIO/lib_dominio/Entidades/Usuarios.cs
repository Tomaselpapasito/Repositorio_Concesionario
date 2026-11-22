using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Cedula { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Telefono { get; set; }

        [NotMapped] public List<Auditorias>? Auditorias { get; set; }
        [NotMapped] public List<Roles>? Roles { get; set; }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
