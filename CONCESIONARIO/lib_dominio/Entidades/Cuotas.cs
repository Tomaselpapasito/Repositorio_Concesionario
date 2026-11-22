using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Cuotas
    {
        [Key]public int ID { get; set; }
        public int Numero_cuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha_vencimiento { get; set; }
        public DateTime? Fecha_pago { get; set; }
        public int Financiamiento { get; set; }

        [ForeignKey("Financiamiento")] public Financiamientos? _Financiamiento { get; set; }

        public bool Validar()
        {
            return this.Numero_cuota <= 0 ||
                this.Monto <= 0 ||
                this.Financiamiento == 0;
        }
    }
}