using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class DetallesVentasProductos
    {
        [Key] public int ID { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
        public int Producto { get; set; }
        public int Venta { get; set; }

        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }

        public bool Validar()
        {
            return this.Precio_Unitario <= 0 ||
                this.Descuento < 0 ||
                this.Subtotal <= 0 ||
                this.Cantidad < 0 ||
                this.Venta == 0 ||
                this.Producto == 0;
        }
    }
}
