using IECBackend.Api.Exceptions.Shared;

namespace IECBackend.Api.Exceptions.Material;

public class MaterialNotFoundExeption(string message): NotFoundException(message)
{
    public static MaterialNotFoundExeption WithSuchId(int id)
    {
        return new MaterialNotFoundExeption($"Material with id '{id}' has not been found");
    }
}