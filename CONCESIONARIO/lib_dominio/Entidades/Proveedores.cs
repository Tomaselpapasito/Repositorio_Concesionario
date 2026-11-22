using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Proveedores
    {
        [Key]public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? NIT { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        [NotMapped]public List<Compras>? Compras { get; set; }

        public bool Validar()
        {
            return string.IsNullOrEmpty(this.NIT) ||
                string.IsNullOrEmpty(this.Nombre) ||
                string.IsNullOrEmpty(this.Telefono) ||
                string.IsNullOrEmpty(this.Correo) ||
                string.IsNullOrEmpty(this.Direccion);
        }
    }
}
