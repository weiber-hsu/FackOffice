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
        if (registerDto.Recommend != null)
        {
            _memberRepo.GetMemberByInvitationCode(registerDto.Recommend);
        }

        var member = registerDto.ToMember();
        member.GetInvitationCode();
        return await _memberRepo.Register(member);
    }
}