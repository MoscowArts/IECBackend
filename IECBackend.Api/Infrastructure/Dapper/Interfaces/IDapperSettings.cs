using IECBackend.Api.Infrastructure.Dapper.Models;

namespace IECBackend.Api.Infrastructure.Dapper.Interfaces;

public interface IDapperSettings
{
    string ConnectionString { get; }
    Provider Provider { get; }
}