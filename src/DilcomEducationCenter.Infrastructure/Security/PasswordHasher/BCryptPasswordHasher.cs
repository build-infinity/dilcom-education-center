using DilcomEducationCenter.Application.Abstractions;

namespace DilcomEducationCenter.Infrastructure.Security.PasswordHasher;

internal sealed class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}