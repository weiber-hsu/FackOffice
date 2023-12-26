using FakeOffice.Models;
using FakeOffice.Service;
using Microsoft.AspNetCore.Mvc;

namespace FakeOffice.Controllers;

//may add white list for security
[ApiController]
[Route("api")]
public class RegisterController : ControllerBase
{
    private readonly IRegisterService _registerService;

    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _registerService.RegisterUser(new RegisterDto()
        {
            UserName = request.UserName,
            Recommend = request.Recommend
        });
        return Ok("Success");
    }
}