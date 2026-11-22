using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Pagos
    {
        [Key]public int ID { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public decimal Monto { get; set; }
        public int Metodo { get; set; }
        public int Venta { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Metodo")] public MetodosPagos? _Metodo { get; set; }
    }
}
