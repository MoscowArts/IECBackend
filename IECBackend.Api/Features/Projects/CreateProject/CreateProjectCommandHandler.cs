
using IECBackend.Api.Features.Users;
using MediatR;

namespace IECBackend.Api.Features.Projects.CreateProject;



public class CreateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, Unit>
{
    
    public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new DbProject() { 
            Name =request.CreateProjectDto.Name,
            Coordinates = request.CreateProjectDto.Coordinates,
            StartDate = request.CreateProjectDto.StartDate,
            EndDate = request.CreateProjectDto.EndDate,
            AssignedContractorId = request.CreateProjectDto.AssignedContractorId,
            AssignedSupervisorId = request.CreateProjectDto.AssignedSupervisorId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        
        await projectRepository.AddAsync(project);
        
        return Unit.Value;
    }
}