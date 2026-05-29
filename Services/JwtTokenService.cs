using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;

namespace CPTMBack.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string token, DateTime expiresAtUtc) GenerateToken(TB_USUARIO usuario)
        {
            var issuer = _configuration["Jwt:Issuer"] ?? "cptm-api";
            var audience = _configuration["Jwt:Audience"] ?? "cptm-web";
            var secret = _configuration["Jwt:Secret"] ?? "MinhaChaveSecretaMuitoForteESegura12345";
            var expiresMinutes = int.TryParse(_configuration["Jwt:ExpiresMinutes"], out var parsedMinutes)
                ? parsedMinutes
                : 120;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAtUtc = DateTime.UtcNow.AddMinutes(expiresMinutes);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.dsLogin),
                new Claim(ClaimTypes.Name, usuario.nmUsuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuario.dsEmail ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAtUtc,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAtUtc);
        }
    }
}
