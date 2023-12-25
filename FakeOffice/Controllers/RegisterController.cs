using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

[ApiController]
[Route("api")]
public class RegisterController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok("Success");
    }
}
public class RegisterRequest
{
    public string? UserName { get; set; }
}