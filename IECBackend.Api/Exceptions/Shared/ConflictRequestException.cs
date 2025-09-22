namespace IECBackend.Api.Exceptions.Shared;

public class ConflictRequestException(string message) : Exception(message);