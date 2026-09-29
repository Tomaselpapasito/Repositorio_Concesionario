public class Servicios  
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Duracion { get; set; }
    public string? Tipo_Servicio { get; set; }

    public List<DetallesServicios>? DetallesServicios { get; set; }
}
