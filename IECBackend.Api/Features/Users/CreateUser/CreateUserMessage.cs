using IECBackend.Api.Common.Abstractions;
using MediatR;

namespace IECBackend.Api.Features.Users.CreateUser;

public record CreateUserMessage(CreateUserRequestDto CreateUserRequestDto) : IMessage<int>;