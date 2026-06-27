using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Application.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByLogin(string login, CancellationToken cancellationToken = default);
    Task <bool> ExistsByEmail(string email, CancellationToken cancellationToken = default);
}