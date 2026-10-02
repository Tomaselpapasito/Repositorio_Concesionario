using System.ComponentModel.DataAnnotations.Schema;

public class Inventarios 
{
    public int ID { get; set; }
    public DateTime Fecha_Ingreso { get; set; }
    public string? Ubicacion { get; set; }
    public int Moto { get; set; }

    [ForeignKey("Moto")] public Motos? _Moto { get; set; }
}
