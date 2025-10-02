using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;
using IECBackend.Api.Infrastructure.Scripts.Issue;

namespace IECBackend.Api.Features.Issues;

public class IssueRepository(IDapperContext<IDapperSettings> dapperContext): IIssueRepository
{
    public async Task AddAsync(DbIssue dbIssue, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Issue.Create, dbIssue), transaction);
    }

    public async Task UpdateAsync(int issueId, DbIssue dbIssue, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Issue.Update, dbIssue), transaction);
    }

    public async Task DeleteAsync(int issueId, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(Issue.Delete, new { Id  = issueId }), transaction);
    }

    public async Task<DbIssue?> GetByIdAsync(int id)
    {
        return await dapperContext.FirstOrDefault<DbIssue>(new QueryObject(Issue.GetById, new { Id = id }));
    }
    public async Task<bool> ExistsAsync(int userId)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(Issue.ExistsById, new { Id  = userId }));
    }
}