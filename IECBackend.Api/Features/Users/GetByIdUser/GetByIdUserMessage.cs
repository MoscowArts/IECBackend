using IECBackend.Api.Common.Abstractions;

namespace IECBackend.Api.Features.Users.GetByIdUser;

public record GetByIdUserMessage(int Id) : IMessage<DbUser>;