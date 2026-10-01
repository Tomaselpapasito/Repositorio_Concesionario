public class Productos
{
    public int ID { get; set; }
    public string? Codigo { get; set; }
    public string? Nombre { get; set; }
    public DateTime Fecha_Creacion { get; set; }
    public DateTime Fecha_Modificacion { get; set; }
    public decimal Precio { get; set; }
    public bool Activo { get; set; }

    public int Stock { get; set; }

    public List<DetallesCompras>? DetallesCompras { get; set; }
    public List<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
}
