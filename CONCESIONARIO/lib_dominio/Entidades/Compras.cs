public class Compras 
{
    public int ID { get; set; }
    public DateTime Fecha_Compra { get; set; }
    public decimal Impuesto { get; set; }
    public string? Numero_Factura { get; set; }
    public decimal Total { get; set; }
    public int Proveedor { get; set; }
    
    public Proveedores? _Proveedor { get; set; }

    public List<DetallesCompras>? DetallesCompras { get; set; }     
}
