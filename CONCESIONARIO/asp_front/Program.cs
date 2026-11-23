
using lib_dominio.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IComunicaciones, Comunicaciones>();

builder.Services.AddScoped<IUsuariosNegocio, UsuariosPresentacion>();
builder.Services.AddScoped<IAutenticacionPresentacion, AutenticacionPresentacion>();

builder.Services.AddScoped<IAccesoriosNegocio, AccesoriosPresentacion>();
builder.Services.AddScoped<ICargosNegocio, CargosPresentacion>();
builder.Services.AddScoped<IClientesNegocio, ClientesPresentacion>();
builder.Services.AddScoped<IComprasNegocio, ComprasPresentacion>();
builder.Services.AddScoped<ICuotasNegocio, CuotasPresentacion>();
builder.Services.AddScoped<IDetallesComprasNegocio, DetallesComprasPresentacion>();
builder.Services.AddScoped<IDetallesVentasMotosNegocio, DetallesVentasMotosPresentacion>();
builder.Services.AddScoped<IDetallesVentasProductosNegocio, DetallesVentasProductosPresentacion>();
builder.Services.AddScoped<IEmpleadosNegocio, EmpleadosPresentacion>();
builder.Services.AddScoped<IFinanciamientosNegocio, FinanciamientosPresentacion>();
builder.Services.AddScoped<IInventariosNegocio, InventariosPresentacion>();
builder.Services.AddScoped<IMetodosPagosNegocio, MetodosPagosPresentacion>();
builder.Services.AddScoped<IModelosMotosNegocio, ModelosMotosPresentacion>();
builder.Services.AddScoped<IMotosNegocio, MotosPresentacion>();
builder.Services.AddScoped<IPagosNegocio, PagosPresentacion>();
builder.Services.AddScoped<IPersonasNegocio, PersonasPresentacion>();
builder.Services.AddScoped<IProductosNegocio, ProductosPresentacion>();
builder.Services.AddScoped<IProveedoresNegocio, ProveedoresPresentacion>();
builder.Services.AddScoped<IRepuestosNegocio, RepuestosPresentacion>();
builder.Services.AddScoped<IVentasNegocio, VentasPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
