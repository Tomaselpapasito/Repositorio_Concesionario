using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorio.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Accesorios>? Accesorios { get; set; }
        DbSet<Cargos>? Cargos { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Compras>? Compras { get; set; }
        DbSet<Cuotas>? Cuotas { get; set; }
        DbSet<DetallesCompras>? DetallesCompras { get; set; }
        DbSet<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
        DbSet<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Financiamientos>? Financiamientos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<MetodosPagos>? MetodosPagos   { get; set; }
        DbSet<ModelosMotos>? ModelosMotos { get; set; }
        DbSet<Motos>? Motos { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Repuestos>? Repuestos { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Ventas>? Ventas { get; set; }

        /**=========================================AUDITORIAS===============================**/

        DbSet<AuditoriasAccesorios>? AuditoriasAccesorios { get; set; }
        DbSet<AuditoriasCargos>? AuditoriasCargos { get; set; }
        DbSet<AuditoriasClientes>? AuditoriasClientes { get; set; }
        DbSet<AuditoriasCompras>? AuditoriasCompras { get; set; }
        DbSet<AuditoriasCuotas>? AuditoriasCuotas { get; set; }
        DbSet<AuditoriasDetallesCompras>? AuditoriasDetallesCompras { get; set; }
        DbSet<AuditoriasDetallesVentasProductos>? AuditoriasDetallesVentasProductos { get; set; }
        DbSet<AuditoriasDetallesVentasMotos>? AuditoriasDetallesVentasMotos { get; set; }
        DbSet<AuditoriasEmpleados>? AuditoriasEmpleados { get; set; }
        DbSet<AuditoriasFinanciamientos>? AuditoriasFinanciamientos { get; set; }
        DbSet<AuditoriasInventarios>? AuditoriasInventarios { get; set; }
        DbSet<AuditoriasMetodosPagos>? AuditoriasMetodosPagos { get; set; }
        DbSet<AuditoriasModelosMotos>? AuditoriasModelosMotos { get; set; }
        DbSet<AuditoriasMotos>? AuditoriasMotos { get; set; }
        DbSet<AuditoriasPagos>? AuditoriasPagos { get; set; }
        DbSet<AuditoriasRoles>? AuditoriasRoles { get; set; }
        DbSet<AuditoriasPermisos>? AuditoriasPermisos { get; set; }
        DbSet<AuditoriasPersonas>? AuditoriasPersonas { get; set; }
        DbSet<AuditoriasProductos>? AuditoriasProductos { get; set; }
        DbSet<AuditoriasProveedores>? AuditoriasProveedores { get; set; }
        DbSet<AuditoriasRepuestos>? AuditoriasRepuestos { get; set; }
        DbSet<AuditoriasUsuarios>? AuditoriasUsuarios { get; set; }
        DbSet<AuditoriasVentas>? AuditoriasVentas { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}