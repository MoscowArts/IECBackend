using IECBackend.Api.Exceptions.Issue;
using MediatR;

namespace IECBackend.Api.Features.Issues.GetByIdIssue;



public class GetByIdIssueCommandHandler(IIssueRepository issueRepository) : IRequestHandler<GetByIdIssueCommand, DbIssue>
{

    public async Task<DbIssue> Handle(GetByIdIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = await issueRepository.GetByIdAsync(request.Id);
        return issue ?? throw IssueNotFoundException.WithSuchId(request.Id);
    }
}