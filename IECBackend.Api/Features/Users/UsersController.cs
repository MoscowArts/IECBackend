using IECBackend.Api.Common.Abstractions;
using IECBackend.Api.Features.Users.DeleteUser;
using IECBackend.Api.Features.Users.GetByIdUser;
using IECBackend.Api.Features.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Users;

public class UsersController(IMediator mediator) : BaseAuthController
{
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetById(int userId, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetByIdUserMessage(userId), cancellationToken);
        return Ok(user);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserMessage(UserId), cancellationToken);
        return Ok();
    }

    [HttpDelete("{userId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int userId, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserMessage(userId), cancellationToken);
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> Update(UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateUserMessage(UserId, request), cancellationToken);
        return Ok();
    }
    
    [HttpPatch("{userId:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int userId, UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        await mediator.Send(new UpdateUserMessage(userId, request), cancellationToken);
        return Ok();
    }
}