using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.User;

/// <summary>
/// Исключение, указывающее на то, что учетная запись уже существует.
/// </summary>
public class UserBadRequestException(string message) : BadRequestException(message)
{
    /// <summary>
    /// Создает новый экземпляр исключения с сообщением о том, что учетная запись с указанным адресом электронной почты уже существует.
    /// </summary>
    /// <param name="email">Адрес электронной почты, который уже используется.</param>
    /// <returns>Новый экземпляр исключения <see cref="UserBadRequestException"/>.</returns>
    public static UserBadRequestException WithSuchEmail(string email)
    {
        return new UserBadRequestException($"User with email '{email}' already exists.");
    }
}