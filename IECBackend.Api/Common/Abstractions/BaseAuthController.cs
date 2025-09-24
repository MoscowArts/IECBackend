using IECBackend.Api.Common.Authentication.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Common.Abstractions;

/// <summary>
/// Базовый контроллер для авторизованных пользователей.
/// </summary>
/// <remarks>
/// Этот абстрактный контроллер предоставляет общие функциональности для всех контроллеров, 
/// которые требуют аутентификации пользователя.
/// </remarks>
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseAuthController : ControllerBase
{
    /// <summary>
    /// Получает значение заголовка авторизации из текущего HTTP-запроса.
    /// </summary>
    private string AuthHeader => HttpContext.Request.Headers.Authorization.ToString();
    
    /// <summary>
    /// Получает идентификатор пользователя из JWT.
    /// </summary>
    protected int UserId => int.Parse(JwtReader.GetId(AuthHeader));
    
    /// <summary>
    /// Получает роль пользователя из JWT.
    /// </summary>
    protected string Role => JwtReader.GetRole(AuthHeader);
    
    /// <summary>
    /// Получает email пользователя из JWT.
    /// </summary>
    protected string Email => JwtReader.GetEmail(AuthHeader);
}