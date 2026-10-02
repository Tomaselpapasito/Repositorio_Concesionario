using System.ComponentModel.DataAnnotations.Schema;

public class Ventas
{
    public int ID { get; set; }
    public DateTime Fecha_Venta { get; set; }
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public int Cliente { get; set; }
    public int Empleado { get; set; }

    [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

    public List<Pagos>? Pagos { get; set; }
    public List<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
    public List<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
}
