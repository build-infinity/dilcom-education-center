using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Application.Abstractions;

public interface ITokenProvider
{
    string Generate(User user);    
}