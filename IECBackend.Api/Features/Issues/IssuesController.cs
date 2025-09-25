using IECBackend.Api.Features.Issues.CreateIssue;
using IECBackend.Api.Features.Issues.DeleteIssue;
using IECBackend.Api.Features.Issues.GetByIdIssue;
using IECBackend.Api.Features.Issues.UpdateIssue;
using IECBackend.Api.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Issues;

[Route("issues/")]
public class IssuesController(IMediator mediator,IMinioService minioService) : Controller
{

    [HttpGet("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int issueId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdIssueCommand(issueId), cancellationToken);
        return Ok(user);
    }
    
    [HttpDelete("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Delete(int issueId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteIssueCommand(issueId), cancellationToken);
        return Ok();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(string Description, string Coordinates,
        DateTime TermOfElimination,IFormFile? Image, CancellationToken cancellationToken)
    {
        if (Image == null || Image.Length == 0)
            return BadRequest("Файл пустой");

        var fileName = $"{Guid.NewGuid()}_{Image.FileName}";

        await using var stream = Image.OpenReadStream();
        
        await minioService.UploadFileAsync(stream, fileName, Image.ContentType);
        var tmp = new IssueRequestDto
        {
            Description = Description,
            Coordinates = Coordinates,
            TermOfElimination = TermOfElimination,
            Image = fileName
        };
        await mediator.Send(new CreateIssueCommand(tmp), cancellationToken);
        return Ok();
    }


    [HttpPatch("{issueId:int}")]
    [AllowAnonymous]
    public async Task<IActionResult> Update(int issueId, IssueRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateIssueCommand(issueId, request), cancellationToken);
        return Ok();
    }
}