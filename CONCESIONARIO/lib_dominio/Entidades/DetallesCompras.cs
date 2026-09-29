public class DetallesCompras
{
    public int ID { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio_Unitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public int Compra { get; set; }
    public int Producto { get; set; }
    
    public Compras? _Compra { get; set; }
    public Productos? _Producto { get; set; }
}