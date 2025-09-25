using IECBackend.Api.Features.Projects.CreateProject;
using IECBackend.Api.Features.Projects.DeleteProject;
using IECBackend.Api.Features.Projects.UpdateProject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Projects;

[Route("[controller]/")]
[ApiController]
public class ProjectsController(IMediator mediator) : Controller
{

    [HttpGet("{projectsId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int projectsId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdProjectCommand(projectsId), cancellationToken);
        return Ok(user);
    }
    
    [HttpDelete("{projectsId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int projectsId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteProjectCommand(projectsId), cancellationToken);
        return Ok();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateProjectRequestDto project, CancellationToken cancellationToken)
    {
        //
        // var tmp = new CreateProjectRequestDto()
        // {
        //
        //     Coordinates = Coordinates,
        //
        // };
        await mediator.Send(new CreateProjectCommand(project), cancellationToken);
        return Ok();
    }


    [HttpPatch("{projectsId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Update(int projectsId, UpdateProjectRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateProjectCommand(projectsId, request), cancellationToken);
        return Ok();
    }
    

}