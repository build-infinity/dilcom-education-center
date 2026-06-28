namespace DilcomEducationCenter.Application.Abstractions;

public interface IUnitOfWork
{
    Task<bool> SaveChanges(CancellationToken cancellationToken = default);
}