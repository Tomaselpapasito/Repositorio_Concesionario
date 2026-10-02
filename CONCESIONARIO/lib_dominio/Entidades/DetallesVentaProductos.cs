using System.ComponentModel.DataAnnotations.Schema;

public class DetallesVentasProductos
{
    public int ID { get; set; }
    public decimal Precio_Unitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public int Cantidad { get; set; }
    public int Producto { get; set; }
    public int Venta { get; set; }

    [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
    [ForeignKey("Producto")] public Productos? _Producto { get; set; }
}
