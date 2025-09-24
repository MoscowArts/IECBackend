using IECBackend.Api.Features.Users.UpdateUser;
using IECBackend.Api.Infrastructure.Dapper.Interfaces;

namespace IECBackend.Api.Features.Users;

public interface IUserRepository
{
    Task<int> AddAsync(DbUser dbUser, ITransaction? transaction = null);
    Task UpdateAsync(int userId, DbUser dbUser, ITransaction? transaction = null);
    Task DeleteAsync(int userId, ITransaction? transaction = null);
    Task<DbUser?> GetByIdAsync(int id);
    Task<DbUser?> GetByEmailAsync(string email);
    Task<bool> ExistsAsync(int userId);
    Task<bool> ExistsAsync(string email);
}