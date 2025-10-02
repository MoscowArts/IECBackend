using MediatR;

namespace IECBackend.Api.Features.Projects.UpdateProject;

public record UpdateProjectCommand(int Id,UpdateProjectRequestDto Project) : IRequest<Unit>;