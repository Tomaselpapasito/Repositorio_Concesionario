public class Cargos
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public decimal Salario { get; set; }
    public bool Activo { get; set; }

    public List<Empleados>? Empleados { get; set; }

}
