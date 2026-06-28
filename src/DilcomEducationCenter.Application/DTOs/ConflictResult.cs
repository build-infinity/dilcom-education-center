namespace DilcomEducationCenter.Application.DTOs;

public record ConflictResult
{
    public bool EmailExists { get; init; }
    public bool PhoneExists { get; init; }
    public bool LoginExists { get; init; }
}