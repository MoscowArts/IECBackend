using IECBackend.Api.Infrastructure.Dapper.Interfaces;

namespace IECBackend.Api.Features.Materials;

public interface IMaterialRepository
{
    Task AddAsync(DbMaterial dbMaterial, ITransaction? transaction = null);
    Task UpdateAsync(int materialId, DbMaterial dbMaterial, ITransaction? transaction = null);
    Task DeleteAsync(int materialId, ITransaction? transaction = null);
    Task<DbMaterial?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
}