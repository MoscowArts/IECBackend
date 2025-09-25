using IECBackend.Api.Exceptions.Project;
using MediatR;

namespace IECBackend.Api.Features.Projects.DeleteProject;



public class GetByIdProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<GetByIdProjectCommand, DbProject>
{
    
    public async Task<DbProject> Handle(GetByIdProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetByIdAsync(request.Id);
        return project ?? throw ProjectNotFoundException.WithSuchId(request.Id);
    }
}