using IECBackend.Api.Common.Abstractions;
using MediatR;

namespace IECBackend.Api.Features.Users.DeleteUser;

public record DeleteUserMessage(int Id) : IMessage<Unit>;