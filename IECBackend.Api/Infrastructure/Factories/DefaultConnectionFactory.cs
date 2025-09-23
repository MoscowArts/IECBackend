using System.Data.Common;
using IECBackend.Api.Infrastructure.Factories.Interfaces;
using Npgsql;

namespace IECBackend.Api.Infrastructure.Factories;

public class DefaultConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    public async Task<DbConnection> CreateAsync()
    {
        var connection = new NpgsqlConnection(configuration.GetConnectionString("Default"));
        await connection.OpenAsync();
        return connection;
    }
}