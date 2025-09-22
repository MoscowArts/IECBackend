using IECBackend.Api.Features.Auth.Login;
using IECBackend.Api.Features.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api.Features.Auth;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginMessage message)
    {
        var result = await mediator.Send(new LoginMessage(message.Email, message.Password));
        
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserRequestDto user)
    {
        await mediator.Send(new CreateUserMessage(user));
        
        return Created();
    }
}