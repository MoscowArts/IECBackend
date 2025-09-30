using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;
using IECBackend.Api.Infrastructure.Scripts.WorkTask;

namespace IECBackend.Api.Features.WorkTask;

public class WorKTaskRepository(IDapperContext<IDapperSettings> dapperContext):IWorkTaskRepository
{
    public async Task AddAsync(DbWorkTask dbWorkTask, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Infrastructure.Scripts.WorkTask.WorkTask.Create, dbWorkTask), transaction);
    }

    public async Task UpdateAsync(int projectId, DbWorkTask dbWorkTask, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Infrastructure.Scripts.WorkTask.WorkTask.Update, dbWorkTask), transaction);
    }

    public async Task DeleteAsync(int projectId, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Infrastructure.Scripts.WorkTask.WorkTask.Delete, new { Id  = projectId}), transaction);
    }

    public async Task<DbWorkTask?> GetByIdAsync(int id)
    {
        return await dapperContext.FirstOrDefault<DbWorkTask>(new QueryObject(Infrastructure.Scripts.WorkTask.WorkTask.GetById, new { Id = id }));
    }


    public async Task<bool> ExistsAsync(int projectId)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(Infrastructure.Scripts.WorkTask.WorkTask.ExistsById, new { Id  = projectId }));
    }
}