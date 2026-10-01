public class DetallesVentasMotos
{
    public int ID { get; set; }
    public decimal Precio_Unitario { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public int Moto { get; set; }
    public int Venta { get; set; }
    
    public Ventas? _Venta { get; set; }
    public Motos? _Moto { get; set; }
}
