using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Productos
    {
        [Key] public int ID { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; }

        public int Stock { get; set; }

        [NotMapped]public List<DetallesCompras>? DetallesCompras { get; set; }
        [NotMapped]public List<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
    }
}
