using MediatR;

namespace IECBackend.Api.Features.Issues.DeleteIssue;

public record DeleteIssueCommand(int Id) : IRequest<Unit>;