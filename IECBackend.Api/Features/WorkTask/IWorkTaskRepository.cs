using IECBackend.Api.Infrastructure.Dapper.Interfaces;

namespace IECBackend.Api.Features.WorkTask;

public interface IWorkTaskRepository
{
    Task AddAsync(DbWorkTask dbWorkTask, ITransaction? transaction = null);
    Task UpdateAsync(int projectId, DbWorkTask dbWorkTask, ITransaction? transaction = null);
    Task DeleteAsync(int projectId, ITransaction? transaction = null);
    Task<DbWorkTask?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
}