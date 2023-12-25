using FakeOffice.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FakeOfficeUnitTests;

public class RegisterControllerTests
{
    private RegisterController _registerController;

    [SetUp]
    public void SetUp()
    {
        _registerController = new RegisterController();
    }


    [Test]
    public void call_register_with_data_will_return_ok_with_success()
    {
        var actionResult = _registerController.Register(new RegisterRequest());
        actionResult.Should().BeOfType<OkObjectResult>();
        var result = actionResult as OkObjectResult;
        result?.Value.Should().BeEquivalentTo("Success");
    }
}