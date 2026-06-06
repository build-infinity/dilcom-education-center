using DilcomEducationCenter.Domain.Common;
using DilcomEducationCenter.Domain.Enums;

namespace DilcomEducationCenter.Domain.Errors;

public static class EmailError
{
    public static readonly Error UnsupportedProvider = new Error ("Email.UnsupportedProvider", "Email must be a Gmail address.", ErrorType.Validation);
    public static readonly Error InvalidFormat = new Error("Email.InvalidFormat", "Email format is invalid", ErrorType.Validation);
    public static readonly Error Empty = new Error ("Email.Empty", "Email cannot be empty.", ErrorType.Validation);
}