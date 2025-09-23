namespace IECBackend.Api.Features.Users;

public enum UserRole
{
    /// <summary>
    /// Прораб (подрядчик)
    /// </summary>
    Foreman,
    /// <summary>
    /// Служба строительного контроля (заказчик)
    /// </summary>
    ControlService,
    /// <summary>
    /// Инспектор контрольного органа
    /// </summary>
    Inspector,
    /// <summary>
    /// Суперпользователь для управления системой
    /// </summary>
    Admin
}