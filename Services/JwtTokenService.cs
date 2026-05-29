using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using Microsoft.IdentityModel.Tokens;

namespace CPTMBack.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(TB_USUARIO usuario);
    }

    public class JwtTokenService : IJwtTokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private const int ExpirationMinutes = 60;

        public JwtTokenService(string secretKey, string issuer, string audience)
        {
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
            _issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
            _audience = audience ?? throw new ArgumentNullException(nameof(audience));
        }

        public string GenerateToken(TB_USUARIO usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresAtUtc = DateTime.UtcNow.AddMinutes(ExpirationMinutes);

            var claims = new[]
            {
                new Claim("sub", usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.nmUsuario),
                new Claim(ClaimTypes.Email, usuario.dsEmail ?? string.Empty),
                new Claim("dsLogin", usuario.dsLogin),
                new Claim("idPerfil", usuario.idPerfil.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAtUtc,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
