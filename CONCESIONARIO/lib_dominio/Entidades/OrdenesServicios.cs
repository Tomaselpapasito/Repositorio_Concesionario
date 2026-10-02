using System.ComponentModel.DataAnnotations.Schema;

public class OrdenesServicios
{
    public int ID { get; set; }
    public DateTime Fecha_Ingreso { get; set; }
    public DateTime Fecha_Salida { get; set; }
    public string? Descripcion { get; set; }
    public decimal Costo_Total { get; set; }
    public int Cliente { get; set; }
    public int Empleado { get; set; }
    public int Moto { get; set; }

    [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
    [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    [ForeignKey("Moto")] public Motos? _Moto { get; set; }
    
    public List<DetallesServicios>? DetallesServicios { get; set; }
}
