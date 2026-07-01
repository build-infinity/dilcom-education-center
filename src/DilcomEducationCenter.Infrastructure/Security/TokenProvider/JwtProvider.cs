using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DilcomEducationCenter.Infrastructure.Security.TokenProvider;

internal sealed class JwtProvider : ITokenProvider
{
    private readonly JwtOptions _jwtOptions;
    public JwtProvider(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    public string GenerateAccessToken(User user)
    {
        var claims = new List<Claim>()
        {
          new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
          new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
          new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
          new Claim(JwtRegisteredClaimNames.Email, user.Email.Value),
          new Claim("role", user.Role.Name)  
        };

        var expiresOnUtc = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessExpiresInMinutes);

        return Generate(claims, _jwtOptions.AccessKey, expiresOnUtc);

    }
    private string Generate(IEnumerable<Claim> claims, string key, DateTime expiresOnUtc)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(keyBytes);

        var algorithm = _jwtOptions.HmacAlgorithm switch
        {
            HmacAlgorithm.HS256 => SecurityAlgorithms.HmacSha256,
            HmacAlgorithm.HS512 => SecurityAlgorithms.HmacSha512,

            _ => throw new InvalidOperationException("Unsupported JWT algorithm")
        };

        SigningCredentials credentials = new SigningCredentials(securityKey, algorithm);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer : _jwtOptions.Issuer,
            audience : _jwtOptions.Audience,
            claims : claims,
            expires : expiresOnUtc,
            signingCredentials : credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}