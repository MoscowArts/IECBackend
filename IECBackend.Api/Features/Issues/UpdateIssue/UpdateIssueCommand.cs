using MediatR;

namespace IECBackend.Api.Features.Issues.UpdateIssue;

public record UpdateIssueCommand(int Id,IssueRequestDto Issue) : IRequest<Unit>;