using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.User;

public class UserConflictException(string message) : ConflictRequestException(message)
{
    public static UserConflictException PasswordDontMatch()
    {
        return new UserConflictException("Password don't match");
    }
}