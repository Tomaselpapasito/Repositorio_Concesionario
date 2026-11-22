using lib_repositorio.Implementaciones;
using lib_repositorio.Interfaces;
using lib_dominio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IConexion,Conexion>();
builder.Services.AddScoped<IAccesoriosNegocio,AccesoriosAplicacion>();
builder.Services.AddScoped<ICargosNegocio, CargosAplicacion>();
builder.Services.AddScoped<IClientesNegocio, ClientesAplicacion>();
builder.Services.AddScoped<IComprasNegocio, ComprasAplicacion>();
builder.Services.AddScoped<ICuotasNegocio, CuotasAplicacion>();
builder.Services.AddScoped<IDetallesComprasNegocio,DetallesComprasAplicacion>();
builder.Services.AddScoped<IDetallesVentasMotosNegocio,DetallesVentasMotosAplicacion>();
builder.Services.AddScoped<IDetallesVentasProductosNegocio, DetallesVentasProductosAplicacion>();
builder.Services.AddScoped<IEmpleadosNegocio, EmpleadosAplicacion>();
builder.Services.AddScoped<IFinanciamientosNegocio, FinanciamientosAplicacion >();
builder.Services.AddScoped<IInventariosNegocio,InventariosAplicacion>();
builder.Services.AddScoped<IMetodosPagosNegocio, MetodosPagosAplicacion>();
builder.Services.AddScoped<IModelosMotosNegocio, ModelosMotosAplicacion>();
builder.Services.AddScoped<IMotosNegocio, MotosAplicacion>();
builder.Services.AddScoped<IPagosNegocio, PagosAplicacion>();
builder.Services.AddScoped<IPersonasNegocio, PersonasAplicacion>();
builder.Services.AddScoped<IProductosNegocio, ProductosAplicacion>();
builder.Services.AddScoped<IProveedoresNegocio, ProveedoresAplicacion>();
builder.Services.AddScoped<IRepuestosNegocio, RepuestosAplicacion>();
builder.Services.AddScoped<IVentasNegocio, VentasAplicacion>();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();