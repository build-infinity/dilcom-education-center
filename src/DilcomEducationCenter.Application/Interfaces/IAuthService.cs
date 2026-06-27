using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Domain.Common;

namespace DilcomEducationCenter.Application.Interfaces;

public interface IAuthService
{
    Task<Result<LoginResponse>> Login(LoginRequest loginRequest, CancellationToken cancellationToken = default);
}