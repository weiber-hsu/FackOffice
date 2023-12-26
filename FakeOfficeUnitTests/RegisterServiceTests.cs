using FakeOffice.Models;
using FakeOffice.Service;
using NSubstitute;

namespace FakeOfficeUnitTests;

[TestFixture]
public class RegisterServiceTests
{
    private RegisterService _registerService;
    private IMemberRepo _memberRepo;

    [SetUp]
    public void SetUp()
    {
        _memberRepo = Substitute.For<IMemberRepo>();
        _registerService = new RegisterService(_memberRepo);
    }

    [Test]
    public void should_call_repo()
    {
        _registerService.RegisterUser(new RegisterDto());
        _memberRepo.Received().Register(Arg.Any<Member>());
    }
}