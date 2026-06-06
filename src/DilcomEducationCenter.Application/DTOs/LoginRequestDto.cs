namespace DilcomEducationCenter.Application.DTOs;

public sealed record LoginRequestDto
{
    public string Login { get; }
    public string Password { get; }

    public LoginRequestDto(string login, string password)
    {
        Login = login;
        Password = password;
    }
}