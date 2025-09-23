using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.Auth;

/// <summary>
/// Исключение, указывающее на то, что пароль недействителен.
/// </summary>
public class BadPasswordException() : BadRequestException("Bad password");