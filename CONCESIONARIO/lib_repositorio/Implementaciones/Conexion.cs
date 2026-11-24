using lib_dominio.Auditorias;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorio.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.ObtenerStringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Accesorios>? Accesorios { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Cuotas>? Cuotas { get; set; }
        public DbSet<DetallesCompras>? DetallesCompras { get; set; }
        public DbSet<DetallesVentasProductos>? DetallesVentasProductos { get; set; }
        public DbSet<DetallesVentasMotos>? DetallesVentasMotos { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Financiamientos>? Financiamientos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<MetodosPagos>? MetodosPagos { get; set; }
        public DbSet<ModelosMotos>? ModelosMotos { get; set; }
        public DbSet<Motos>? Motos { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Personas>? Personas { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Repuestos>? Repuestos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }

        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }


        /**=========================AUDITORIAS=========================**/
        public DbSet<AuditoriasAccesorios>? AuditoriasAccesorios { get; set; }
        public DbSet<AuditoriasCargos>? AuditoriasCargos { get; set; }
        public DbSet<AuditoriasClientes>? AuditoriasClientes { get; set; }
        public DbSet<AuditoriasCompras>? AuditoriasCompras { get; set; }
        public DbSet<AuditoriasCuotas>? AuditoriasCuotas { get; set; }
        public DbSet<AuditoriasDetallesCompras>? AuditoriasDetallesCompras { get; set; }
        public DbSet<AuditoriasDetallesVentasProductos>? AuditoriasDetallesVentasProductos { get; set; }
        public DbSet<AuditoriasDetallesVentasMotos>? AuditoriasDetallesVentasMotos { get; set; }
        public DbSet<AuditoriasEmpleados>? AuditoriasEmpleados { get; set; }
        public DbSet<AuditoriasFinanciamientos>? AuditoriasFinanciamientos { get; set; }
        public DbSet<AuditoriasInventarios>? AuditoriasInventarios { get; set; }
        public DbSet<AuditoriasMetodosPagos>? AuditoriasMetodosPagos { get; set; }
        public DbSet<AuditoriasModelosMotos>? AuditoriasModelosMotos { get; set; }
        public DbSet<AuditoriasMotos>? AuditoriasMotos { get; set; }
        public DbSet<AuditoriasPagos>? AuditoriasPagos { get; set; }
        public DbSet<AuditoriasRoles>? AuditoriasRoles { get; set; }
        public DbSet<AuditoriasPermisos>? AuditoriasPermisos { get; set; }
        public DbSet<AuditoriasPersonas>? AuditoriasPersonas { get; set; }
        public DbSet<AuditoriasProductos>? AuditoriasProductos { get; set; }
        public DbSet<AuditoriasProveedores>? AuditoriasProveedores { get; set; }
        public DbSet<AuditoriasRepuestos>? AuditoriasRepuestos { get; set; }
        public DbSet<AuditoriasUsuarios>? AuditoriasUsuarios { get; set; }
        public DbSet<AuditoriasVentas>? AuditoriasVentas { get; set; }



    }
}
