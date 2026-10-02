using System.ComponentModel.DataAnnotations.Schema;

public class DetallesServicios
{
    public int ID { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal Descuento { get; set; }
    public decimal Subtotal { get; set; }
    public int Orden { get; set; }
    public int Servicio { get; set; }
    
    [ForeignKey("Orden")]public OrdenesServicios? _Orden { get; set; }
    [ForeignKey("Servicio")]public Servicios? _Servicio { get; set; }
}
