public class Accesorios 
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Categoria { get; set; }
    public string? Marca { get; set; }
    public int Producto { get; set; }
    
    public Productos? _Producto { get; set; }
}
