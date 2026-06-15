namespace DilcomEducationCenter.Application.DTOs;

public sealed record LoginRequest
{
    public string Login { get; }
    public string Password { get; }

    public LoginRequest(string login, string password)
    {
        Login = login;
        Password = password;
    }
}