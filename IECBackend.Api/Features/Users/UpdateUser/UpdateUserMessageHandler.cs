using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Common.Authentication.Hash.Interfaces;
using IECBackend.Api.Exceptions.User;
using MediatR;

namespace IECBackend.Api.Features.Users.UpdateUser;

public class UpdateUserMessageHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    : IMessageHandler<UpdateUserMessage, Unit>
{
    public async Task<Unit> Handle(UpdateUserMessage request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.Id);
        if (user == null)
            throw UserNotFoundException.WithSuchId(request.Id);

        if (!string.IsNullOrEmpty(request.UpdateUserRequestDto.NewPassword))
        {
            var isVerifyPassword = passwordHasher.Verify(request.UpdateUserRequestDto.OldPassword, user.PasswordHash);
            if (!isVerifyPassword)
                throw UserConflictException.PasswordDontMatch();

            var newPassword = passwordHasher.Hash(request.UpdateUserRequestDto.NewPassword);
            
            user.PasswordHash=newPassword;
            user.Fullname = request.UpdateUserRequestDto.Fullname;
            user.Email = request.UpdateUserRequestDto.Email;
            user.Phone = request.UpdateUserRequestDto.Phone;
            user.UpdatedAt = DateTime.UtcNow;
            
            await userRepository.UpdateAsync(request.Id, user);
        }
        
        return Unit.Value;
    }
}