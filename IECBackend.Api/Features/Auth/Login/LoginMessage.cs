using IECBackend.Api.Common.Abstractions;

namespace IECBackend.Api.Features.Auth.Login;

public record LoginMessage(string Email, string Password) : IMessage<TokenDto>;