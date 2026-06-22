using DilcomEducationCenter.Domain.Entities;

namespace DilcomEducationCenter.Application.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByLogin(string login);
    Task <bool> ExistsByEmail(string email);
}