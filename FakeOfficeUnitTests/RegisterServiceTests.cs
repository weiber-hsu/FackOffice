﻿using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service;
using NSubstitute;

namespace FakeOfficeUnitTests;

[TestFixture]
public class RegisterServiceTests
{
    private const string? AnyUserName = "AnyUserName";
    private const string? AnyRecommend = "AnyRecommend";
    private const int AnyPk = 123;
    private IMemberRepo _memberRepo;
    private RegisterService _registerService;

    [SetUp]
    public void SetUp()
    {
        _memberRepo = Substitute.For<IMemberRepo>();
        _registerService = new RegisterService(_memberRepo);
    }

    [Test]
    public async Task should_call_repo_with_data()
    {
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));

        await _memberRepo.Received().Register(Arg.Is<Member>(m =>
            m.username == AnyUserName && m.recommend == AnyRecommend));
    }

    [Test]
    public async Task should_return_invitation_code()
    {
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));
        await _memberRepo.Received().Register(Arg.Is<Member>(m => m.invitation_code!.Length == 7));
    }

    [Test]
    public async Task should_call_get_member_by_invitation_code()
    {
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));
        await _memberRepo.Received().GetMemberByInvitationCode(AnyRecommend!);
    }

    [Test]
    public async Task should_not_call_get_member_when_recommend_is_null()
    {
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, null));
        await _memberRepo.DidNotReceive().GetMemberByInvitationCode(Arg.Any<string>());
    }

    [Test]
    public async Task agent_fk_should_not_be_zero_with_recommend_code()
    {
        _memberRepo.GetMemberByInvitationCode(Arg.Any<string>()).Returns(new Member() { pk = AnyPk });
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));
        await _memberRepo.Received().Register(Arg.Is<Member>(m => m.agent_fk != 0));
    }

    [Test]
    public async Task agent_fk_should_be_zero_without_recommend_code()
    {
        _memberRepo.GetMemberByInvitationCode(Arg.Any<string>()).Returns(new Member());
        await _registerService.RegisterUser(GivenRegisterDto(AnyUserName, AnyRecommend));
        await _memberRepo.Received().Register(Arg.Is<Member>(m => m.agent_fk == 0));
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