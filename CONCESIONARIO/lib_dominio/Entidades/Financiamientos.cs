public class Financiamientos 
{
    public int ID { get; set; }
    public decimal Monto { get; set; }
    public int Numero_Cuotas { get; set; }
    public decimal Tasa_Interes { get; set; }
    public DateTime Fecha_Inicio { get; set; }
    public DateTime Fecha_Fin { get; set; }
    public int Venta { get; set; }
    public string? Estado { get; set; }

    public Ventas? _Venta { get; set; }

    public List<Cuotas>? Cuotas { get; set; }
}
