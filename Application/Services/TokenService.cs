using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _key;

        public TokenService(IConfiguration configuration)
        {
            // Leer la clave desde el archivo de configuración
            _key = configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(_key))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }
        }

        public string GenerateToken(int userId, string userType, int? professorId = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()), // ID del usuario
                new Claim(ClaimTypes.Role, userType) // Tipo de usuario (Admin, Professor, Student)
            };

            // Agregar el professorId si el usuario es un profesor
            if (professorId.HasValue)
            {
                claims.Add(new Claim("professorId", professorId.Value.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Configurar tiempo de expiración
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
