using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Exceptions.User;

namespace IECBackend.Api.Features.Users.GetByIdUser;

public class GetByIdUserMessageHandler(IUserRepository userRepository) : IMessageHandler<GetByIdUserMessage, GetByIdUserResponseDto>
{
    public async Task<GetByIdUserResponseDto> Handle(GetByIdUserMessage request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw UserNotFoundException.WithSuchId(request.Id);

        var userDto = new GetByIdUserResponseDto
        {
            Fullname = user.Fullname,
            Email = user.Email,
            Phone = user.Phone,
            Role = user.Role,
            Organization = user.Organization,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
        
        return userDto;
    }
}