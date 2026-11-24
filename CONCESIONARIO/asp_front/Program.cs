
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IAutenticacionPresentacion, AutenticacionPresentacion>();
builder.Services.AddScoped<IAccesoriosPresentacion, AccesoriosPresentacion>();
builder.Services.AddScoped<ICargosPresentacion, CargosPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
builder.Services.AddScoped<ICuotasPresentacion, CuotasPresentacion>();
builder.Services.AddScoped<IDetallesComprasPresentacion, DetallesComprasPresentacion>();
builder.Services.AddScoped<IDetallesVentasMotosPresentacion, DetallesVentasMotosPresentacion>();
builder.Services.AddScoped<IDetallesVentasProductosPresentacion, DetallesVentasProductosPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<IFinanciamientosPresentacion, FinanciamientosPresentacion>();
builder.Services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
builder.Services.AddScoped<IMetodosPagosPresentacion, MetodosPagosPresentacion>();
builder.Services.AddScoped<IModelosMotosPresentacion, ModelosMotosPresentacion>();
builder.Services.AddScoped<IMotosPresentacion, MotosPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IRepuestosPresentacion, RepuestosPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();

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
