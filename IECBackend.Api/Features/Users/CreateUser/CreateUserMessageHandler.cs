using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Common.Authentication.Hash.Interfaces;
using IECBackend.Api.Exceptions.User;
using MediatR;

namespace IECBackend.Api.Features.Users.CreateUser;

public class CreateUserMessageHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IMessageHandler<CreateUserMessage, Unit>
{
    public async Task<Unit> Handle(CreateUserMessage request, CancellationToken cancellationToken)
    {
        var isCreated = await userRepository.ExistsAsync(request.CreateUserRequestDto.Email);
        if (isCreated)
            throw UserBadRequestException.WithSuchEmail(request.CreateUserRequestDto.Email);
        
        var password = passwordHasher.Hash(request.CreateUserRequestDto.Password);
        var dbUser = new DbUser
        {
            Username = request.CreateUserRequestDto.Username,
            PasswordHash = password,
            Fullname = request.CreateUserRequestDto.Fullname,
            Email = request.CreateUserRequestDto.Email,
            Phone = request.CreateUserRequestDto.Phone,
            Role = request.CreateUserRequestDto.Role,
            Organization = request.CreateUserRequestDto.Organization,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        
        await userRepository.AddAsync(dbUser);
        
        return Unit.Value;
    }
}