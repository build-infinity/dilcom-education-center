using System.Net.Mail;
using DilcomEducationCenter.Domain.Common;
using DilcomEducationCenter.Domain.Errors;

namespace DilcomEducationCenter.Domain.ValueObjects;

public sealed record Email
{
    private const string SupportedProvider = "gmail.com";
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        if(string.IsNullOrWhiteSpace(value)) 
            return Result<Email>.Failure(EmailErrors.Empty);

        value = value.Trim();

        if(!MailAddress.TryCreate(value, out var mailAddress))
            return Result<Email>.Failure(EmailErrors.InvalidFormat);

        if(!mailAddress.Address.Equals(value, StringComparison.OrdinalIgnoreCase))
            return Result<Email>.Failure(EmailErrors.InvalidFormat);
        
        if(!mailAddress.Host.Equals(SupportedProvider, StringComparison.OrdinalIgnoreCase))
            return Result<Email>.Failure(EmailErrors.UnsupportedProvider);
        
        return Result<Email>.Success(new Email(mailAddress.Address.ToLowerInvariant()));
    }
    public override string ToString() => Value;
}