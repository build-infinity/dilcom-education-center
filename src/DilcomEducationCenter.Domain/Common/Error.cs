using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Common;

public sealed record  Error
{
    public string Code  { get; }
    public string Message { get; }
    public ErrorType ErrorType { get; }

    public Error (string code, string  message, ErrorType errorType)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }
}