using Microsoft.OpenApi.Models;

namespace IECBackend.Api.Extensions;

/// <summary>
/// Расширения для конфигурации служб в приложении.
/// </summary>
/// <remarks>
/// Этот класс содержит методы для добавления аутентификации JWT и настройки Swagger с поддержкой авторизации.
/// </remarks>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Добавляет поддержку Swagger с авторизацией в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddSwaggerWithAuth(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "IEC Backend.Api",
                Description = "API монолита для хакатона",
                Version = "1.1.1.1"
            });

            var schema = new OpenApiSecurityScheme
            {
                Description = "Использование заголовка Authorization со схемой Bearer.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", schema);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { schema, new[] { "Bearer" } }
            });
        });
    }
}