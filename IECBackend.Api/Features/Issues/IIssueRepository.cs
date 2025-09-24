namespace IECBackend.Api.Features.Issues;
using IECBackend.Api.Infrastructure.Dapper.Interfaces;

public interface IIssueRepository
{
    Task AddAsync(DbIssue dbIssue, ITransaction? transaction = null);
    Task UpdateAsync(int issueId, DbIssue dbIssue, ITransaction? transaction = null);
    Task DeleteAsync(int issueId, ITransaction? transaction = null);
    Task<DbIssue?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int userId);
}