using IECBackend.Api.Features.WorkTask.CreateWorkTask;
using IECBackend.Api.Features.WorkTask.DeleteWorkTask;
using IECBackend.Api.Features.WorkTask.GetByIdWorkTask;
using IECBackend.Api.Features.WorkTask.UpdateWorkTask;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.WorkTask;

[Route("[controller]/")]
[ApiController]
public class WorkTaskController(IMediator mediator) : Controller
{

    [HttpGet("{workTaskId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int workTaskId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdWorkTaskCommand(workTaskId), cancellationToken);
        return Ok(user);
    }
    
    [HttpDelete("{workTaskId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int workTaskId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteWorkTaskCommand(workTaskId), cancellationToken);
        return Ok();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateWorkTaskRequestDto workTask, CancellationToken cancellationToken)
    {

        await mediator.Send(new CreateWorkTaskCommand(workTask), cancellationToken);
        return Ok();
    }


    [HttpPatch("{workTaskId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Update(int workTaskId, UpdateWorkTaskRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateWorkTaskCommand(workTaskId, request), cancellationToken);
        return Ok();
    }
    

}