using IECBackend.Api.Features.Materials.CreateMaterial;
using IECBackend.Api.Features.Materials.DeleteMaterial;
using IECBackend.Api.Features.Materials.GetByIdMaterial;
using IECBackend.Api.Features.Materials.UpdateMaterial;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Materials;

[Route("[controller]/")]
[ApiController]
public class MaterialController(IMediator mediator) : Controller
{

    [HttpGet("{materialId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int materialId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdMaterialCommand(materialId), cancellationToken);
        return Ok(user);
    }
    
    [HttpDelete("{materialId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int materialId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteMaterialCommand(materialId), cancellationToken);
        return Ok();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateMaterialRequestDto project, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateMaterialCommand(project), cancellationToken);
        return Ok();
    }


    [HttpPatch("{materialId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Update(int materialId, UpdateMaterialRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateMaterialCommand(materialId, request), cancellationToken);
        return Ok();
    }
    

}