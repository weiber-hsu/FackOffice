using FakeOffice.Models;
using FakeOffice.Repository;

namespace FakeOffice.Service;

public class RegisterService : IRegisterService
{
    private readonly IMemberRepo _memberRepo;

    public RegisterService(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
    }

    public async Task<string?> RegisterUser(RegisterDto registerDto)
    {
        var member = registerDto.ToMember();
        if (registerDto.Recommend != null)
        {
            var invitationCodeOwner = _memberRepo.GetMemberByInvitationCode(registerDto.Recommend);
            member.agent_fk = invitationCodeOwner.pk;
        }

        member.GetInvitationCode();
        return await _memberRepo.Register(member);
    }
}