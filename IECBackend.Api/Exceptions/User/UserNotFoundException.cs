using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.User;

public class UserNotFoundException(string message) : NotFoundException(message)
{
    public static UserNotFoundException WithSuchId(int id)
    {
        return new UserNotFoundException($"User with id '{id}' has not been found");
    }
    
    public static UserNotFoundException WithSuchEmail(string email)
    {
        return new UserNotFoundException($"User with email '{email}' has not been found");
    }
}