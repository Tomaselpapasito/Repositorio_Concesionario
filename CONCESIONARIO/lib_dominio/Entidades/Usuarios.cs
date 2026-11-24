using lib_dominio.Auditorias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int ID { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }

        [NotMapped] public List<Roles>? Roles { get; set; }

        [NotMapped] public List<AuditoriasAccesorios>? AuditoriasAccesorios { get; set; }
        [NotMapped] public List<AuditoriasCargos>? AuditoriasCargos { get; set; }
        [NotMapped] public List<AuditoriasClientes>? AuditoriasClientes { get; set; }
        [NotMapped] public List<AuditoriasCompras>? AuditoriasCompras { get; set; }
        [NotMapped] public List<AuditoriasCuotas>? AuditoriasCuotas { get; set; }
        [NotMapped] public List<AuditoriasDetallesCompras>? AuditoriasDetallesCompras { get; set; }
        [NotMapped] public List<AuditoriasDetallesVentasMotos>? AuditoriasDetallesVentasMotos { get; set; }
        [NotMapped] public List<AuditoriasDetallesVentasProductos>? AuditoriasDetallesVentasProductos { get; set; }
        [NotMapped] public List<AuditoriasEmpleados>? AuditoriasEmpleados { get; set; }
        [NotMapped] public List<AuditoriasFinanciamientos>? AuditoriasFinanciamientos { get; set; }
        [NotMapped] public List<AuditoriasInventarios>? AuditoriasInventarios { get; set; }
        [NotMapped] public List<AuditoriasMetodosPagos>? AuditoriasMetodosPagos { get; set; }
        [NotMapped] public List<AuditoriasModelosMotos>? AuditoriasModelosMotos { get; set; }
        [NotMapped] public List<AuditoriasMotos>? AuditoriasMotos { get; set; }
        [NotMapped] public List<AuditoriasPagos>? AuditoriasPagos { get; set; }
        [NotMapped] public List<AuditoriasPersonas>? AuditoriasPersonas { get; set; }
        [NotMapped] public List<AuditoriasProductos>? AuditoriasProductos { get; set; }
        [NotMapped] public List<AuditoriasProveedores>? AuditoriasProveedores { get; set; }
        [NotMapped] public List<AuditoriasRepuestos>? AuditoriasRepuestos { get; set; }
        [NotMapped] public List<AuditoriasVentas>? AuditoriasVentas { get; set; }

        public bool Validar()
        {
            return string.IsNullOrWhiteSpace(this.NombreUsuario) ||
                string.IsNullOrWhiteSpace(this.Contraseña);
        }
    }
}
