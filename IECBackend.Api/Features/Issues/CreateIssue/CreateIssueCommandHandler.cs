using MediatR;

namespace IECBackend.Api.Features.Issues.CreateIssue;



public class CreateIssueCommandHandler(IIssueRepository issueRepository) : IRequestHandler<CreateIssueCommand, Unit>
{
    
    public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        if(request.issue.TermOfElimination == null)
            throw new ArgumentNullException(nameof(request.issue.TermOfElimination));
        
        var issue = new DbIssue { 
            Description = request.issue.Description, 
            Coordinates = request.issue.Coordinates,
            TermOfElimination=(DateTime)request.issue.TermOfElimination, 
            Image = request.issue.Image,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
        
        await issueRepository.AddAsync(issue);
        
        return Unit.Value;
    }
}