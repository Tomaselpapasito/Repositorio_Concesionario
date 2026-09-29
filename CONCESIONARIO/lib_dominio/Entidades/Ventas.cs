public class Ventas
{
    public int ID { get; set; }
    public DateTime Fecha_Venta { get; set; }
    public decimal Impuestos { get; set; }
    public decimal Total { get; set; }
    public int Cliente { get; set; }
    public int Empleado { get; set; }

    public Empleados? _Empleado { get; set; }
    public Clientes? _Cliente { get; set; }

    public List<Pagos>? Pagos { get; set; }
    public List<DetallesVentas>? DetallesVentas { get; set; }
}
