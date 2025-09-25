using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;
using IECBackend.Api.Infrastructure.Scripts.Project;

namespace IECBackend.Api.Features.Projects;

public class ProjectRepository(IDapperContext<IDapperSettings> dapperContext): IProjectRepository{
    
    public async Task AddAsync(DbProject dbProject, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Project.Create, dbProject), transaction);
    }

    public async Task UpdateAsync(int projectId, DbProject dbProject, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Project.Update, dbProject), transaction);
    }

    public async Task DeleteAsync(int projectId, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Project.Delete, new { Id  = projectId}), transaction);
    }

    public async Task<DbProject?> GetByIdAsync(int id)
    {
        return await dapperContext.FirstOrDefault<DbProject>(new QueryObject(Project.GetById, new { Id = id }));
    }


    public async Task<bool> ExistsAsync(int projectId)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(Project.ExistsById, new { Id  = projectId }));
    }
}