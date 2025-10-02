using MediatR;

namespace IECBackend.Api.Features.WorkTask.GetByIdWorkTask;

public record GetByIdWorkTaskCommand(int Id) : IRequest<DbWorkTask>;