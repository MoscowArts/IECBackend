using IECBackend.Api.Exceptions.Issue;
using MediatR;

namespace IECBackend.Api.Features.Issues.DeleteIssue;



public class DeleteIssueCommandHandler(IIssueRepository issueRepository) : IRequestHandler<DeleteIssueCommand, Unit>
{
    
    public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
    {
        if(!await issueRepository.ExistsAsync(request.Id))
            throw IssueNotFoundException.WithSuchId(request.Id);
        
        await issueRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}