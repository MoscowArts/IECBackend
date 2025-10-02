using MediatR;

namespace IECBackend.Api.Features.WorkTask.DeleteWorkTask;

public record DeleteWorkTaskCommand(int Id) : IRequest<Unit>;