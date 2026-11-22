using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class DetallesVentasMotos
    {
        [Key] public int ID { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public int Moto { get; set; }
        public int Venta { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Moto")] public Motos? _Moto { get; set; }

        public bool Validar()
        {
            return this.Precio_Unitario <= 0 ||
                this.Descuento < 0 ||
                this.Subtotal <= 0 ||
                this.Moto == 0 ||
                this.Venta == 0;
        }

    }
}


