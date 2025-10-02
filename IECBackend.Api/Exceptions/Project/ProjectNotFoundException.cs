using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.Project;

public class ProjectNotFoundException(string message): NotFoundException(message)
{
    public static ProjectNotFoundException WithSuchId(int id)
    {
        return new ProjectNotFoundException($"Project with id '{id}' has not been found");
    }
}