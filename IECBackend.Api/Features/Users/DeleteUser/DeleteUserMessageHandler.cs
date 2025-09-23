using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Exceptions.User;
using MediatR;

namespace IECBackend.Api.Features.Users.DeleteUser;

public class DeleteUserMessageHandler(IUserRepository userRepository) : IMessageHandler<DeleteUserMessage, Unit>
{
    public async Task<Unit> Handle(DeleteUserMessage request, CancellationToken cancellationToken)
    {
        if(!await userRepository.ExistsAsync(request.Id))
            throw UserNotFoundException.WithSuchId(request.Id);
        
        await userRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}