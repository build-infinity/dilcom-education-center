namespace DilcomEducationCenter.Application.DTOs;

public sealed record LoginResponse
{
    public string Token { get; }

    public LoginResponse(string token)
    {
        Token = token;
    }
 }