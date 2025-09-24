using System.Security.Claims;
using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Common.Authentication.Hash.Interfaces;
using IECBackend.Api.Exceptions.Auth;
using IECBackend.Api.Exceptions.User;
using IECBackend.Api.Features.Users;
using IECBackend.Api.Services.Interfaces;

namespace IECBackend.Api.Features.Auth.Login;

public class LoginMessageHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService jwtService) : IMessageHandler<LoginMessage, TokenDto>
{
    public async Task<TokenDto> Handle(LoginMessage request, CancellationToken cancellationToken)
    {
        var candidate = await userRepository.GetByEmailAsync(request.Email);
        if (candidate == null)
            throw UserNotFoundException.WithSuchEmail(request.Email);
        
        if (!passwordHasher.Verify(request.Password, candidate.PasswordHash))
            throw new BadPasswordException();
        
        var token = await jwtService.CreateAccessTokenAsync(new List<Claim>
        {
            new("email", request.Email),
            new("role", candidate.Role.ToString()),
            new("id", candidate.Id.ToString())
        });

        return token;
    }
}