using IECBackend.Api.Features.Auth.Login;
using IECBackend.Api.Features.Users;
using IECBackend.Api.Features.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Auth;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginMessage message, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new LoginMessage(message.Email, message.Password), cancellationToken);
        
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserRequestDto user, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(new CreateUserMessage(user), cancellationToken);
        
        return CreatedAtAction(
            actionName: nameof(UsersController.GetById),
            controllerName: "Users",
            routeValues: new { userId = id },
            value: null
        );    }
}