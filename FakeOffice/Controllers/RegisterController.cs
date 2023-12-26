using FakeOffice.Models;
using FakeOffice.Service;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

[ApiController]
[Route("api")]
public class RegisterController : ControllerBase
{
    private IRegisterService _registerService;

    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok("Success");
    }
}