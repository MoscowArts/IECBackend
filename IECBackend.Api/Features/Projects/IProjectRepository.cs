
using IECBackend.Api.Infrastructure.Dapper.Interfaces;

namespace IECBackend.Api.Features.Projects;

public interface IProjectRepository
{
    Task AddAsync(DbProject dbProject, ITransaction? transaction = null);
    Task UpdateAsync(int projectId, DbProject dbProject, ITransaction? transaction = null);
    Task DeleteAsync(int projectId, ITransaction? transaction = null);
    Task<DbProject?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    
}