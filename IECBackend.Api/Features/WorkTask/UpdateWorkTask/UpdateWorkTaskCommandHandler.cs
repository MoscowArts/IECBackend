using IECBackend.Api.Exceptions.WorkTask;
using MediatR;

namespace IECBackend.Api.Features.WorkTask.UpdateWorkTask;



public class UpdateWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository) : IRequestHandler<UpdateWorkTaskCommand, Unit>
{

    public async Task<Unit> Handle(UpdateWorkTaskCommand request, CancellationToken cancellationToken)
    {
        var workTask = await workTaskRepository.GetByIdAsync(request.Id);
        if (workTask == null)
            throw WorkTaskNotFoundException.WithSuchId(request.Id);
        workTask.Name = request.WorkTask.Name??workTask.Name;
        workTask.ProjectId = request.WorkTask.ProjectId??workTask.ProjectId;
        workTask.PlannedStart=request.WorkTask.PlannedStart??workTask.PlannedStart;
        workTask.PlannedEnd=request.WorkTask.PlannedEnd??workTask.PlannedEnd;
        workTask.Status=request.WorkTask.Status??workTask.Status;
        workTask.UpdatedAt=DateTime.UtcNow;

        await workTaskRepository.UpdateAsync(workTask.Id, workTask);
        
        return Unit.Value;
    }
}