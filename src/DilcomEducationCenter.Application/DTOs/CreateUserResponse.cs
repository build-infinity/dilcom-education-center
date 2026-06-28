namespace DilcomEducationCenter.Application.DTOs;

public sealed record CreateUserResponse
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public DateOnly BirthDate { get; init; }
    public string  Email { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public string Gender { get; init; } = null!;
    public string Role { get; init; } = null!;
}