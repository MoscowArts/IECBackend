using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Dapper.Models;

namespace IECBackend.Api.Infrastructure.Dapper;

public class IecDataBase(IConfiguration configuration) : IDapperSettings
{
    public string ConnectionString => configuration["IecDataBase:ConnectionString"] ?? string.Empty;
    public Provider Provider => Enum.Parse<Provider>(configuration["IecDataBase:Provider"] ?? string.Empty);
}