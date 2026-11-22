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

        [NotMapped]public List<Cuotas>? Cuotas { get; set; }

        public bool Validar()
        {
            return
                this.Monto < 0 ||
                this.Numero_Cuotas <= 0 ||
                this.Tasa_Interes < 0 ||
                this.Venta == 0;
        }
    }
}
