using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;
using IECBackend.Api.Infrastructure.Scripts.Material;

namespace IECBackend.Api.Features.Materials;

public class MaterialRepository(IDapperContext<IDapperSettings> dapperContext):IMaterialRepository
{
    public async Task AddAsync(DbMaterial dbMaterial, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Material.Create, dbMaterial), transaction);
    }

    public async Task UpdateAsync(int materialId, DbMaterial dbMaterial, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Material.Update, dbMaterial), transaction);
    }

    public async Task DeleteAsync(int materialId, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Material.Delete, new { Id  = materialId}), transaction);
    }

    public async Task<DbMaterial?> GetByIdAsync(int id)
    {
        return await dapperContext.FirstOrDefault<DbMaterial>(new QueryObject(Material.GetById, new { Id = id }));
    }


    public async Task<bool> ExistsAsync(int materialId)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(Material.ExistsById, new { Id  = materialId }));
    }
}