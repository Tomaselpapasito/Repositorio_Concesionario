using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Repuestos
    {
        [Key]public int ID { get; set; }
        public string? Numero_Parte { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha_Modificacion { get; set; }
        public int Producto { get; set; }

        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
    }
}
