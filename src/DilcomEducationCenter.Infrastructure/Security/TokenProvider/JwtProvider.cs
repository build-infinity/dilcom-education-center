using DilcomEducationCenter.Application.Abstractions;
using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Infrastructure.Security.TokenProvider;


public sealed class JwtProvider : ITokenProvider
{
    
    public string Generate(User user)
    {
        return string.Empty;
    }
}