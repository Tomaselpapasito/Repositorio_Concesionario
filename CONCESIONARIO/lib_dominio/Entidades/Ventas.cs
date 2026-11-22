using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Ventas
    {
        [Key]public int ID { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Total { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }

        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        [NotMapped]public List<Pagos>? Pagos { get; set; }
        [NotMapped] public List<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
        [NotMapped] public List<DetallesVentasProductos>? DetallesVentasProductos { get; set; }

        public bool Validar()
        {
            return
                this.Fecha_Venta == default ||
                this.Impuestos <= 0 ||
                this.Total < 0 ||
                this.Cliente == 0 ||
                this.Empleado == 0;
        }
    }

}