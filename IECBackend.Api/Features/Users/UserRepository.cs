using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;
using IECBackend.Api.Infrastructure.Scripts.User;

namespace IECBackend.Api.Features.Users;

public class UserRepository(IDapperContext<IDapperSettings> dapperContext) : IUserRepository
{
    public async Task<int> AddAsync(DbUser dbUser, ITransaction? transaction = null)
    {
        return await dapperContext.CommandWithResponse<int>(new QueryObject(User.Create, dbUser), transaction);
    }

    public async Task UpdateAsync(int userId, DbUser dbUser, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(User.Update, dbUser), transaction);
    }

    public async Task DeleteAsync(int userId, ITransaction? transaction = null)
    {
        await dapperContext.Command(new QueryObject(User.Delete, new { Id  = userId }), transaction);
    }

    public async Task<DbUser?> GetByIdAsync(int id)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(User.GetById, new { Id = id }));
    }

    public async Task<DbUser?> GetByEmailAsync(string email)
    {
        return await dapperContext.FirstOrDefault<DbUser>(new QueryObject(User.GetByEmail, new { Email = email }));
    }

    public async Task<bool> ExistsAsync(int userId)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(User.ExistsById, new { Id  = userId }));
    }

    public async Task<bool> ExistsAsync(string email)
    {
        return await dapperContext.CommandWithResponse<bool>(new QueryObject(User.ExistsByEmail,
            new { Email = email }));
    }
}