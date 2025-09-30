using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.WorkTask;

public class WorkTaskNotFoundException(string message): NotFoundException(message)
{
    public static WorkTaskNotFoundException WithSuchId(int id)
    {
        return new WorkTaskNotFoundException($"Task with id '{id}' has not been found");
    }
}