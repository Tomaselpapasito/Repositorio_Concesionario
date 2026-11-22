using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Financiamientos
    {
        [Key]public int ID { get; set; }
        public decimal Monto { get; set; }
        public int Numero_Cuotas { get; set; }
        public decimal Tasa_Interes { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public int Venta { get; set; }
        public string? Estado { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }

        public List<Cuotas>? Cuotas { get; set; }
    }
}
