using DilcomEducationCenter.Domain.Enums;
using DilcomEducationCenter.Domain.Common;

namespace DilcomEducationCenter.Application.Errors;

public static class AuthError
{
    public static readonly Error InvalidCredentials = new Error("Auth.InvalidCredentials", "Login or password is incorrect", ErrorType.Unauthorized);
}