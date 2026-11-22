using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class DetallesCompras
    {
        [Key]public int ID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public int Compra { get; set; }
        public int Producto { get; set; }

        [ForeignKey("Compra")] public Compras? _Compra { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public bool Validar()
        {
            return this.Cantidad <= 0 ||
                this.Precio_Unitario <= 0 ||
                this.Descuento < 0 ||
                this.Subtotal <= 0 ||
                this.Compra == 0 ||
                this.Producto == 0;


        }

    }
}