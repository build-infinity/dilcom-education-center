namespace DilcomEducationCenter.Application.DTOs;

public sealed record LoginResponseDto
{
    public string Token { get; }

    public LoginResponseDto(string token)
    {
        Token = token;
    }
 }