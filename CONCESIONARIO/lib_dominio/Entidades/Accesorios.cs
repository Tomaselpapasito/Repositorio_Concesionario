using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Accesorios 
{
    [Key]public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Categoria { get; set; }
    public string? Marca { get; set; }
    public int Producto { get; set; }

    [ForeignKey("Producto")] public Productos? _Producto { get; set; }
}
