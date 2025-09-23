using IECBackend.Api.Common.Abstractions;
using MediatR;

namespace IECBackend.Api.Features.Users.UpdateUser;

public record UpdateUserMessage(int Id, UpdateUserRequestDto UpdateUserRequestDto) : IMessage<Unit>;