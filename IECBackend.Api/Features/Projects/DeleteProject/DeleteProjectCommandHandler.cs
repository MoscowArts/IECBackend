using IECBackend.Api.Exceptions.Issue;
using MediatR;

namespace IECBackend.Api.Features.Projects.DeleteProject;



public class DeleteProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<DeleteProjectCommand, Unit>
{
    
    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        if(!await projectRepository.ExistsAsync(request.Id))
            throw IssueNotFoundException.WithSuchId(request.Id);
        
        await projectRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}