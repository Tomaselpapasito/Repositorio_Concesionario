using lib_dominio.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_dominio.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Accesorios>? Accesorios { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Cuotas>? Cuotas { get; set; }
        public DbSet<DetallesCompras>? DetallesCompras { get; set; }
        public DbSet<DetallesServicios>? DetallesServicios { get; set; }
        public DbSet<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
        public DbSet<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Financiamientos>? Financiamientos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<MetodosPagos>? MetodosPagos { get; set; }
        public DbSet<ModelosMotos>? ModelosMotos { get; set; }
        public DbSet<Motos>? Motos { get; set; }
        public DbSet<OrdenesServicios>? OrdenesServicios { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Repuestos>? Repuestos { get; set; }
        public DbSet<Servicios>? Servicios { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }

    }
}
