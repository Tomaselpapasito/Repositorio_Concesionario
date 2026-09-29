public class Productos
{
    public int ID { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public decimal Precio { get; set; }
    public bool Activo { get; set; }

    public List<DetallesCompras>? DetallesCompras { get; set; }
}
