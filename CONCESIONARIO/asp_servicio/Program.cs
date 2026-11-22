using lib_dominio.Implementaciones;
using lib_dominio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IConexion,Conexion>();
builder.Services.AddScoped<IAccesoriosAplicacion,AccesoriosAplicacion>();
builder.Services.AddScoped<ICargosAplicacion,CargosAplicacion>();
builder.Services.AddScoped<IClientesAplicacion,ClientesAplicacion>();
builder.Services.AddScoped<IComprasAplicacion,ComprasAplicacion>();
builder.Services.AddScoped<ICuotasAplicacion,CuotasAplicacion>();
builder.Services.AddScoped<IDetallesComprasAplicacion,DetallesComprasAplicacion>();
builder.Services.AddScoped<IDetallesServiciosAplicacion,DetallesServiciosAplicacion>();
builder.Services.AddScoped<IDetallesVentasMotosAplicacion,DetallesVentasMotosAplicacion>();
builder.Services.AddScoped<IDetallesVentasProductosAplicacion,DetallesVentasProductosAplicacion>();
builder.Services.AddScoped<IEmpleadosAplicacion,EmpleadosAplicacion>();
builder.Services.AddScoped<IFinanciamientosAplicacion,FinanciamientosAplicacion >();
builder.Services.AddScoped<IInventariosAplicacion,InventariosAplicacion>();
builder.Services.AddScoped<IMetodosPagosAplicacion,MetodosPagosAplicacion>();
builder.Services.AddScoped<IModelosMotosAplicacion,ModelosMotosAplicacion>();
builder.Services.AddScoped<IMotosAplicacion,MotosAplicacion>();
builder.Services.AddScoped<IOrdenesServiciosAplicacion,OrdenesServiciosAplicacion>();
builder.Services.AddScoped<IPagosAplicacion,PagosAplicacion>();
builder.Services.AddScoped<IPersonasAplicacion,PersonasAplicacion>();
builder.Services.AddScoped<IProductosAplicacion,ProductosAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion,ProveedoresAplicacion>();
builder.Services.AddScoped<IRepuestosAplicacion,RepuestosAplicacion>();
builder.Services.AddScoped<IServiciosAplicacion,ServiciosAplicacion>();
builder.Services.AddScoped<IVentasAplicacion,VentasAplicacion>();


var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();