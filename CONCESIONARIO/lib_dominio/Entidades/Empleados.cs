public class Empleados 
{
    public int ID { get; set; }
    public string? Carnet { get; set; }
    public DateTime Fecha_Contratacion { get; set; }
    public int Persona { get; set; }
    public int Cargo { get; set; }

    public Cargos? _Cargo { get; set; }
    public Personas? _Persona { get; set; }

    public List<Ventas>? Ventas { get; set; }
    public List<OrdenesServicios>? OrdenesServicios { get; set; }
}
