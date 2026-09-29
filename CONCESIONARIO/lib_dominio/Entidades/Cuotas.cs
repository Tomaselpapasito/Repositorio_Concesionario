public class Cuotas 
{
    public int ID { get; set; }
    public int Numero_cuota { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha_vencimiento { get; set; }
    public DateTime? Fecha_pago { get; set; }
    public int Financiamiento { get; set; }
    
    public Financiamientos? _Financiamiento { get; set; }
}
