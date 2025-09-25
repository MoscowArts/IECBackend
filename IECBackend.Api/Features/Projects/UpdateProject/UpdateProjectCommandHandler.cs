using IECBackend.Api.Exceptions.Project;
using MediatR;

namespace IECBackend.Api.Features.Projects.UpdateProject;



public class UpdateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<UpdateProjectCommand, Unit>
{

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetByIdAsync(request.Id);
        if (project == null)
            throw ProjectNotFoundException.WithSuchId(request.Id);
        project.Name = request.Project.Name?? project.Coordinates;
        project.Coordinates = request.Project.Coordinates ?? project.Coordinates;
        project.StartDate = request.Project.StartDate ?? project.StartDate;
        project.EndDate = request.Project.EndDate ?? project.EndDate;
        project.AssignedContractorId = request.Project.ConstractorId ?? project.AssignedContractorId;
        project.AssignedSupervisorId = request.Project.SupervisorId ?? project.AssignedSupervisorId;
        project.UpdatedAt=DateTime.UtcNow;
        await projectRepository.UpdateAsync(project.Id, project);
        
        return Unit.Value;
    }
}