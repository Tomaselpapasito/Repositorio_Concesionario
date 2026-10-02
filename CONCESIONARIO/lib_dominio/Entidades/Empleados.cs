using System.ComponentModel.DataAnnotations.Schema;

public class Empleados 
{
    public int ID { get; set; }
    public string? Carnet { get; set; }
    public DateTime Fecha_Contratacion { get; set; }
    public int Persona { get; set; }
    public int Cargo { get; set; }

    [ForeignKey("Cargo")] public Cargos? _Cargo { get; set; }
    [ForeignKey("Persona")] public Personas? _Persona { get; set; }

    public List<Ventas>? Ventas { get; set; }
    public List<OrdenesServicios>? OrdenesServicios { get; set; }
}
