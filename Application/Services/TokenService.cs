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

        public string GenerateToken(int userId, string userType, int? professorId = null, bool isHeadOfAssignment = false)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        new Claim(ClaimTypes.Role, userType),
        new Claim("IsHeadOfAssignment", isHeadOfAssignment.ToString()) // Nuevo claim
    };

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
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
