namespace DilcomEducationCenter.Infrastructure.Security.TokenProvider;

public sealed class JwtOptions
{
    public HmacAlgorithm HmacAlgorithm  { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string AccessKey { get; set; } = null!;
    public int AccessExpiresInMinutes { get; set; }
}