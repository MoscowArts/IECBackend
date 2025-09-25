using MediatR;

namespace IECBackend.Api.Features.Projects.DeleteProject;

public record GetByIdProjectCommand(int Id) : IRequest<DbProject>;