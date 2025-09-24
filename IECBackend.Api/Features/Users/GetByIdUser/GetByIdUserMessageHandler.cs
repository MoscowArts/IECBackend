using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Exceptions.User;

namespace IECBackend.Api.Features.Users.GetByIdUser;

public class GetByIdUserMessageHandler(IUserRepository userRepository) : IMessageHandler<GetByIdUserMessage, DbUser>
{
    public async Task<DbUser> Handle(GetByIdUserMessage request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        return user ?? throw UserNotFoundException.WithSuchId(request.Id);
    }
}