using MediatR;

namespace IECBackend.Api.Features.WorkTask.CreateWorkTask;



public class CreateWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository) : IRequestHandler<CreateWorkTaskCommand, Unit>
{
    
    public async Task<Unit> Handle(CreateWorkTaskCommand request, CancellationToken cancellationToken)
    {
        DbWorkTask workTask = new()
        {
            ProjectId = request.CreateWorkTaskRequestDto.ProjectId,
            Name = request.CreateWorkTaskRequestDto.Name,
            PlannedStart = request.CreateWorkTaskRequestDto.PlannedStart,
            PlannedEnd = request.CreateWorkTaskRequestDto.PlannedEnd,
            Status = request.CreateWorkTaskRequestDto.Status,   
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        await workTaskRepository.AddAsync(workTask);
        
        return Unit.Value;
    }
}