using DbUp;
using FluentValidation;
using IECBackend.Api.Behaviors;
using IECBackend.Api.Features.Issues;
using IECBackend.Api.Features.Materials;
using IECBackend.Api.Features.Projects;
using IECBackend.Api.Features.Users;
using IECBackend.Api.Features.WorkTask;
using IECBackend.Api.Infrastructure.Dapper;
using IECBackend.Api.Infrastructure.Dapper.Interfaces;
using IECBackend.Api.Infrastructure.Factories;
using IECBackend.Api.Infrastructure.Factories.Interfaces;
using IECBackend.Api.Services;
using IECBackend.Api.Services.Interfaces;
using MediatR;
using Minio;

namespace IECBackend.Api.Extensions;

/// <summary>
/// Расширения для настройки инфраструктурных компонентов приложения.
/// </summary>
/// <remarks>
/// Этот класс содержит методы для настройки базы данных и регистрации репозиториев и фабрик в контейнере зависимостей.
/// </remarks>
public static class InfrastructureHostExtensions
{
    /// <summary>
    /// Выполняет миграцию базы данных для указанного контекста.
    /// </summary>
    public static IServiceCollection MigrateDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["IecDataBase:ConnectionString"];

        EnsureDatabase.For.PostgresqlDatabase(connectionString);
        
        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(DapperContext<>).Assembly)
            .WithTransaction()
            .WithVariablesDisabled()
            .LogToConsole()
            .Build();

        if (upgrader.IsUpgradeRequired())
            upgrader.PerformUpgrade();

        return services;
    }
    
    /// <summary>
    /// Подключение Даппера.
    /// </summary>
    public static IServiceCollection AddDapper(this IServiceCollection services)
    {
        return services
            .AddSingleton<IDapperSettings, IecDataBase>()
            .AddSingleton<IDapperContext<IDapperSettings>, DapperContext<IDapperSettings>>();
    }
    
    /// <summary>
    /// Добавляет инфраструктурные сервисы в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnectionFactory, DefaultConnectionFactory>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IIssueRepository, IssueRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IWorkTaskRepository, WorKTaskRepository>();
    }
    
    /// <summary>
    /// Подключение и настройка библиотеки FluentValidation.
    /// </summary>
    /// <param name="services"></param>
    // ReSharper disable once UnusedMethodReturnValue.Global
    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
    
    /// <summary>
    /// Подключение хранилища файлов.
    /// </summary>
    public static IServiceCollection AddMinio(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<IMinioClient>(_ =>
                new MinioClient()
                    .WithEndpoint(configuration["Minio:Endpoint"])
                    .WithCredentials(configuration["Minio:AccessKey"], configuration["Minio:SecretKey"])
                    .WithSSL(false)
                    .Build());
    }
    
    /// <summary>
    /// Добавляет сервисы приложения в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IMinioService, MinioService>();
    }
}