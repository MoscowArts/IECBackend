using IECBackend.Api.Exceptions.Issue;
using IECBackend.Api.Features.Issues.GetByIdIssue;
using MediatR;

namespace IECBackend.Api.Features.Issues.UpdateIssue;



public class UpdateIssueCommandHandler(IIssueRepository issueRepository) : IRequestHandler<UpdateIssueCommand, Unit>
{

    public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await issueRepository.GetByIdAsync(request.Id);
        if (issue == null)
            throw IssueNotFoundException.WithSuchId(request.Id);
        
        issue.Coordinates = request.Issue.Coordinates ?? issue.Coordinates;
        issue.Description = request.Issue.Description ?? issue.Description;
        issue.Image = request.Issue.Image ?? issue.Image;
        issue.TermOfElimination = request.Issue.TermOfElimination ?? issue.TermOfElimination;
        await issueRepository.UpdateAsync(issue.Id, issue);
        
        return Unit.Value;
    }
}