using System.ComponentModel.DataAnnotations.Schema;

public class Repuestos 
{
    public int ID { get; set; }
    public string? Numero_Parte { get; set; }
    public string? Descripcion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    public int Producto { get; set; }

    [ForeignKey("Producto")] public Productos? _Producto { get; set; }
}
