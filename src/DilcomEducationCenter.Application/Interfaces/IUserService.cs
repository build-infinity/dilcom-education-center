
using DilcomEducationCenter.Application.DTOs;
using DilcomEducationCenter.Domain.Common;

namespace DilcomEducationCenter.Application.Interfaces;

public interface IUserService
{
    Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest createUserRequest, string creatorRole, CancellationToken cancellationToken = default);
}