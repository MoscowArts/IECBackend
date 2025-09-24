using IECBackend.Api.Features.Issues.UpdateIssue;
using MediatR;

namespace IECBackend.Api.Features.Issues.CreateIssue;

public record CreateIssueCommand(IssueRequestDto issue) 
    : IRequest<Unit>;