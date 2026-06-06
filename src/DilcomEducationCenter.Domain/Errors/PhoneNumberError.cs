using DilcomEducationCenter.Domain.Common;

namespace DilcomEducationCenter.Domain.Enums;

public static class PhoneNumberError
{
    public static readonly Error Empty = new Error("PhoneNumber.Empty", "Phone number is required.", ErrorType.Validation);
    public static readonly Error InvalidFormat = new Error("PhoneNumber.InvalidFormat", "Phone number must contain only '+' and digits.", ErrorType.Validation);
    public static readonly Error InvalidCountryCode = new Error("PhoneNumber.InvalidCountryCode", "Phone number must start with '+993'.", ErrorType.Validation);
    public static readonly Error InvalidLength = new Error("PhoneNumber.InvalidLength","Phone number must contain exacatly 11 digits including country code.", ErrorType.Validation); 
}