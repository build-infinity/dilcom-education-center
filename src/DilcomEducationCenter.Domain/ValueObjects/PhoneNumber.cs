using DilcomEducationCenter.Domain.Common;
using DilcomEducationCenter.Domain.Enums;

using System.Text.RegularExpressions;
namespace DilcomEducationCenter.Domain.ValueObjects;

public sealed record PhoneNumber
{
    private const string CountryCode = "993";
    public const int TotalDigits = 11;
    private static readonly Regex OnlyDigitsWithPlusRegex = new(@"^\+\d+$", RegexOptions.Compiled);
    public string Value { get; }

    private PhoneNumber(string value)
    {
        Value = value; 
    }

    public static Result<PhoneNumber> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.Empty);
        
        value = Normalize(value);

        if(!OnlyDigitsWithPlusRegex.IsMatch(value))
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.InvalidFormat);

        if (!value.StartsWith("+" + CountryCode, StringComparison.Ordinal))
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.InvalidCountryCode);
        
        string digitdOnly = value[1..];

        if(digitdOnly.Length != TotalDigits)
            return Result<PhoneNumber>.Failure(PhoneNumberErrors.InvalidLength);

        return Result<PhoneNumber>.Success(new PhoneNumber(value));
    }

    public override string ToString() => Value;

    private static string Normalize(string value)
    {
        value = value
           .Trim()
           .Replace("-", "")
           .Replace("(", "")
           .Replace(")", "");

        return new string(value.Where(c => !char.IsWhiteSpace(c)).ToArray());
    }
}