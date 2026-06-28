using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Application.Abstractions;

public interface IRoleRepository
{
    Task<Role?> GetByName(string role, CancellationToken cancellationToken = default);
}