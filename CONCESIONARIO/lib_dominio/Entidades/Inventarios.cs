public class Inventarios 
{
    public int ID { get; set; }
    public DateTime Fecha_Ingreso { get; set; }
    public string? Ubicacion { get; set; }
    public int Moto { get; set; }
    
    public Motos? _Moto { get; set; }
}
