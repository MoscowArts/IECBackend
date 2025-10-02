using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.Issue;

public class IssueNotFoundException(string message): NotFoundException(message)
{
    public static IssueNotFoundException WithSuchId(int id)
    {
        return new IssueNotFoundException($"Issue with id '{id}' has not been found");
    }
}