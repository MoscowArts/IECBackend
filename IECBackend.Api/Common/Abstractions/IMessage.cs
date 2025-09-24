using MediatR;

namespace IECBackend.Api.Common.Abstractions;

public interface IMessage<out TResponse> : IRequest<TResponse>;