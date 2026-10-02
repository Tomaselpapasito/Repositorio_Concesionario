using System.ComponentModel.DataAnnotations.Schema;

public class Motos 
{
    public int ID { get; set; }
    public string? VIN { get; set; }
    public string? Numero_Motor { get; set; }
    public string? Color { get; set; }
    public int Anio { get; set; }
    public int Modelo { get; set; }
    public string? Estado { get; set; }

    [ForeignKey("Modelo")] public ModelosMotos? _Modelo { get; set; }

    public List<OrdenesServicios>? OrdenesServicios { get; set; }
}
