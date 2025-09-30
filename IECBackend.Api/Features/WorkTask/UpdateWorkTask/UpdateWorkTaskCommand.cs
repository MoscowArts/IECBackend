using MediatR;

namespace IECBackend.Api.Features.WorkTask.UpdateWorkTask;

public record UpdateWorkTaskCommand(int Id,UpdateWorkTaskRequestDto WorkTask) : IRequest<Unit>;