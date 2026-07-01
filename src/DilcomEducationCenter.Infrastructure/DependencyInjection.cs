using System.Text;
using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Infrastructure.Security.PasswordHasher;
using DilcomEducationCenter.Infrastructure.Security.TokenProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DilcomEducationCenter.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
        services.AddSingleton<ITokenProvider, JwtProvider>();

        var jwt = configuration.GetSection("JwtOptions").Get<JwtOptions>()!;

        services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options => 
                {
                   options.MapInboundClaims = false;
 
                   options.TokenValidationParameters  = new TokenValidationParameters
                   {
                      ValidateIssuer = true,
                      ValidIssuer = jwt.Issuer,

                      ValidateAudience = true,
                      ValidAudience = jwt.Audience,

                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.AccessKey)),
                      
                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.Zero,

                      NameClaimType = "sub",
                      RoleClaimType = "role"
                   };
                });

        return services;
    }
}