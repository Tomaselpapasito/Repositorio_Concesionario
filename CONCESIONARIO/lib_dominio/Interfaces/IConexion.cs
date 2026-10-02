using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_dominio.interfaces
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
        DbSet<DetallesServicios>? DetallesServicios { get; set; }
        DbSet<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
        DbSet<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Financiamientos>? Financiamientos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<MetodosPagos>? MetodosPagos   { get; set; }
        DbSet<ModelosMotos>? ModelosMotos { get; set; }
        DbSet<Motos>? Motos { get; set; }
        DbSet<OrdenesServicios>? OrdenesServicios { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Personas>? Personas { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Repuestos>? Repuestos { get; set; }
        DbSet<Servicios>? Servicios { get; set; }
        DbSet<Ventas>? Ventas { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}