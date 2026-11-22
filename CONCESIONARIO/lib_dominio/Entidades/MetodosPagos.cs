using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class MetodosPagos
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }

        [NotMapped]public List<Pagos>? Pagos { get; set; }
    }
}
