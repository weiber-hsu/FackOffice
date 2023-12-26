using FakeOffice.Controllers;
using FakeOffice.Models;
using FakeOffice.Service;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace FakeOfficeUnitTests;

public class RegisterControllerTests
{
    private RegisterController _registerController;
    private IRegisterService _registerService;

    [SetUp]
    public void SetUp()
    {
        _registerService = Substitute.For<IRegisterService>();
        _registerController = new RegisterController(_registerService);
    }

    [Test]
    public async Task call_register_with_data_will_return_ok_with_success()
    {
        var actionResult = await _registerController.Register(new RegisterRequest());
        var result = actionResult as OkObjectResult;
        actionResult.Should().BeOfType<OkObjectResult>();
        result?.Value.Should().BeEquivalentTo("Success");
    }

    [Test]
    public void should_call_register_service_with_domain_model()
    {
        var registerRequest = new RegisterRequest()
        {
            UserName = "AnyUserName",
            Recommend = "AnyRecommend"
        };

        _registerController.Register(registerRequest);
        _registerService.Received().RegisterUser(Arg.Any<RegisterDto>());
    }
}