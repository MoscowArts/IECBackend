using MediatR;

namespace IECBackend.Api.Features.Projects.DeleteProject;

public record DeleteProjectCommand(int Id) : IRequest<Unit>;