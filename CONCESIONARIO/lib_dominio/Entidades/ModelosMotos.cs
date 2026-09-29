public class ModelosMotos
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public int Cilindraje { get; set; }
    public string? Tipo_motor { get; set; }
    public string? Transmision { get; set; }
    public decimal Potencia { get; set; }

    public List<Motos>? Motos { get; set; }
}
