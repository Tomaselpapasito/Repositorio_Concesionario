public class MetodosPagos 
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Tipo { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; }

    public List<Pagos>? Pagos { get; set; }
}
