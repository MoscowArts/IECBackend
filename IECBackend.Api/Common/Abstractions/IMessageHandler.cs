using MediatR;

namespace IECBackend.Api.Common.Abstractions;

public interface IMessageHandler<in TMessage, TResponse> : IRequestHandler<TMessage, TResponse>
    where TMessage : IMessage<TResponse>;