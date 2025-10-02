using IECBackend.Api.Exceptions.WorkTask;
using MediatR;

namespace IECBackend.Api.Features.WorkTask.GetByIdWorkTask;



public class GetByIdWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository) : IRequestHandler<GetByIdWorkTaskCommand, DbWorkTask>
{
    
    public async Task<DbWorkTask> Handle(GetByIdWorkTaskCommand request, CancellationToken cancellationToken)
    {
        var project = await workTaskRepository.GetByIdAsync(request.Id);
        return project ?? throw WorkTaskNotFoundException.WithSuchId(request.Id);
    }
}