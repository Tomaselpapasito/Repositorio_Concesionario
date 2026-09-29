public class Proveedores
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? NIT { get; set; }
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public string? Direccion { get; set; }

    public List<Compras>? Compras { get; set; }
}
