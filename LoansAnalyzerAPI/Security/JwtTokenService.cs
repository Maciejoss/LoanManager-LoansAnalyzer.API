using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LoansAnalyzerAPI.Security;

public class JwtTokenService
{
    private readonly JwtSettings _jwtSettings;
    
    public JwtTokenService(IOptions<JwtSettings> settings)
    {
        _jwtSettings = settings.Value;
    }
    
    public JwtSettings GetJwtSettings()
    {
        return _jwtSettings;
    }

    public string BuildJwtToken(string userName)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var jwtClaims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: jwtClaims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddSeconds(_jwtSettings.LifetimeInSeconds),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}