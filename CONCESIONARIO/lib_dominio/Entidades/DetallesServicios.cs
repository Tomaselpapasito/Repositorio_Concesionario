public class DetallesServicios
{
    public int ID { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public int Orden { get; set; }
    public int Servicio { get; set; }
    
    public OrdenesServicios? _Orden { get; set; }
    public Servicios? _Servicio { get; set; }
}
