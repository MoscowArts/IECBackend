using MediatR;

namespace IECBackend.Api.Features.Projects.CreateProject;

public record CreateProjectCommand(CreateProjectRequestDto CreateProjectDto) 
    : IRequest<Unit>;