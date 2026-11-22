using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Compras
    {
        public int ID { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public decimal Impuesto { get; set; }
        public string? Numero_Factura { get; set; }
        public decimal Total { get; set; }
        public int Proveedor { get; set; }

        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }

        [NotMapped]public List<DetallesCompras>? DetallesCompras { get; set; }
        public bool Validar()
        {
            return this.Fecha_Compra == default ||
                   this.Impuesto < 0 ||
                   string.IsNullOrWhiteSpace(this.Numero_Factura) ||
                   this.Total <= 0 ||
                   this.Proveedor == 0;
        }
    }
}