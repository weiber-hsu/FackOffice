﻿using FakeOffice.Models;
using FakeOffice.Service;
using FakeOffice.Service.Interface;
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
        var result = await _registerService.RegisterUser(new RegisterDto()
        {
            UserName = request.UserName,
            Recommend = request.Recommend
        });

        return Ok(result);
    }
}