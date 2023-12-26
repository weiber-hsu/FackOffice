using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service;
using NSubstitute;

namespace FakeOfficeUnitTests;

[TestFixture]
public class RegisterServiceTests
{
    private const string? AnyUserName = "AnyUserName";
    private const string? AnyRecommend = "AnyRecommend";
    private IMemberRepo _memberRepo;
    private RegisterService _registerService;

    [SetUp]
    public void SetUp()
    {
        _memberRepo = Substitute.For<IMemberRepo>();
        _registerService = new RegisterService(_memberRepo);
    }

    [Test]
    public void should_call_repo_with_data()
    {
        _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));

        _memberRepo.Received().Register(Arg.Is<Member>(m =>
            m.username == AnyUserName && m.recommend == AnyRecommend));
    }

    [Test]
    public async Task should_return_invitation_code()
    {
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));
        _memberRepo.Received().Register(Arg.Is<Member>(m => m.invitation_code.Length == 7));
    }

    private static RegisterDto GivenRegisterDto(string? userName, string? anyRecommend)
    {
        return new RegisterDto()
        {
            UserName = userName,
            Recommend = anyRecommend
        };
    }
}