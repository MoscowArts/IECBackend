using IECBackend.Api.Exceptions.WorkTask;
using MediatR;

namespace IECBackend.Api.Features.WorkTask.DeleteWorkTask;



public class DeleteWorkTaskCommandHandler(IWorkTaskRepository workTaskRepository) : IRequestHandler<DeleteWorkTaskCommand, Unit>
{
    
    public async Task<Unit> Handle(DeleteWorkTaskCommand request, CancellationToken cancellationToken)
    {
        if(!await workTaskRepository.ExistsAsync(request.Id))
            throw WorkTaskNotFoundException.WithSuchId(request.Id);
        
        await workTaskRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}