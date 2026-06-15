using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Application.Abstractions;

public interface ITokenProvider
{
    string GenerateAccessToken(User user);    
}