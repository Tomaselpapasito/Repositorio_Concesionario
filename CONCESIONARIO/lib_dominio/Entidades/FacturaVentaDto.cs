using System;
using System.Collections.Generic;
using System.Text;

namespace lib_dominio.Entidades
{
    public class FacturaVentaDto
    {
        public int ID { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Total { get; set; }

        public string ClienteNombre { get; set; } = "";
        public string ClienteCedula { get; set; } = "";
        public string ClienteTelefono { get; set; } = "";
        public string ClienteCorreo { get; set; } = "";
        public string ClienteDireccion { get; set; } = "";

        public string EmpleadoNombre { get; set; } = "";
        public string EmpleadoCedula { get; set; } = "";
        public string EmpleadoCarnet { get; set; } = "";

        public List<FacturaMotoDto> Motos { get; set; } = new();

        public List<FacturaProductoDto> Productos { get; set; } = new();
    }

    public class FacturaMotoDto
    {
        public string Modelo { get; set; } = "";
        public string VIN { get; set; } = "";
        public string NumeroMotor { get; set; } = "";
        public string Color { get; set; } = "";

        public int Anio { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Descuento { get; set; }

        public decimal Subtotal { get; set; }
    }

    public class FacturaProductoDto
    {
        public string Codigo { get; set; } = "";

        public string Nombre { get; set; } = "";

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Descuento { get; set; }

        public decimal Subtotal { get; set; }
    }
}
