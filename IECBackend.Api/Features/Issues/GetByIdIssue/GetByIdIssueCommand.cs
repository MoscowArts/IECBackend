using MediatR;

namespace IECBackend.Api.Features.Issues.GetByIdIssue;

public record GetByIdIssueCommand(int Id) : IRequest<DbIssue>;