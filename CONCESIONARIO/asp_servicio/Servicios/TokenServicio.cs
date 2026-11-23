using lib_dominio.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace asp_servicio.Servicios
{
    public class TokenServicio
    {
        private readonly IConfiguration IConfiguration;

        public TokenServicio(IConfiguration IConfiguration)
        {
            this.IConfiguration = IConfiguration;
        }

        public string GenerarToken(Usuarios usuario)
        {
            var claims = new[]
            {
            new Claim(
                ClaimTypes.NameIdentifier,
                usuario.ID.ToString()
            ),

            new Claim(
                ClaimTypes.Name,
                usuario.NombreUsuario!
            )
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    IConfiguration["Jwt:Key"]!
                )
            );

            var credenciales = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: IConfiguration["Jwt:Issuer"],
                audience: IConfiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(
                        IConfiguration["Jwt:DurationMinutes"]!
                    )
                ),
                signingCredentials: credenciales
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
