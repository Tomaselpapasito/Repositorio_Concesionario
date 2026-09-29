public class Clientes
{
    public int ID { get; set; }
    public string? Correo { get; set; }
    public string? Numero_Licencia { get; set; }
    public string? Direccion { get; set; }
    public bool Activo { get; set; }
    public int Persona { get; set; }
    
    public Personas? _Persona { get; set; }

    public List<Ventas>? Ventas { get; set; }
    public List<OrdenesServicios>? OrdenesServicios { get; set; }
}
