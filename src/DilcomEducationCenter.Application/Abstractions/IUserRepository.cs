using DilcomEducationCenter.Domain.Entities;
using DilcomEducationCenter.Application.DTOs;

namespace DilcomEducationCenter.Application.Abstractions;

public interface IUserRepository
{
    void Add(User user);
    Task<User?> GetById(int id, CancellationToken cancellationToken = default); 
    Task<User?> GetByLogin(string login, CancellationToken cancellationToken = default);
    Task <bool> ExistsByEmail(string email, CancellationToken cancellationToken = default);
    Task<ConflictResult> FindConflictAsync(string email, string phone, string login, CancellationToken cancellationToken = default);
}