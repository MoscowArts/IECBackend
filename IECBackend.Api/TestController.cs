using IECBackend.Api.Common.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api;

public class TestController : BaseAuthController
{

    [HttpGet]
    public IActionResult gey()
    {
        return Ok("Hello");
    }
}