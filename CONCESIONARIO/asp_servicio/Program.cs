
using asp_servicio.Servicios;
using lib_dominio.Interfaces;
using lib_repositorio.Implementaciones;
using lib_repositorio.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IAccesoriosAplicacion, AccesoriosAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<ICargosAplicacion, CargosAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<IComprasAplicacion, ComprasAplicacion>();
builder.Services.AddScoped<ICuotasAplicacion, CuotasAplicacion>();
builder.Services.AddScoped<IDetallesComprasAplicacion, DetallesComprasAplicacion>();
builder.Services.AddScoped<IDetallesVentasMotosAplicacion, DetallesVentasMotosAplicacion>();
builder.Services.AddScoped<IDetallesVentasProductosAplicacion, DetallesVentasProductosAplicacion>();
builder.Services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
builder.Services.AddScoped<IFinanciamientosAplicacion, FinanciamientosAplicacion>();
builder.Services.AddScoped<IInventariosAplicacion, InventariosAplicacion>();
builder.Services.AddScoped<IMetodosPagosAplicacion, MetodosPagosAplicacion>();
builder.Services.AddScoped<IModelosMotosAplicacion, ModelosMotosAplicacion>();
builder.Services.AddScoped<IMotosAplicacion, MotosAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
builder.Services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
builder.Services.AddScoped<IRepuestosAplicacion, RepuestosAplicacion>();
builder.Services.AddScoped<IVentasAplicacion, VentasAplicacion>();
builder.Services.AddScoped<IAuditorias, AuditoriasAplicacion>();

builder.Services.AddScoped<IAutenticacion, AutenticacionAplicacion>();
builder.Services.AddScoped<TokenServicio>();

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:Key"]!
                )
            )
        };
});

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
