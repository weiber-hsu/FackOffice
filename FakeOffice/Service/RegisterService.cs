using System.Security.Cryptography;
using System.Text;
using FakeOffice.Models;
using FakeOffice.Repository;

namespace FakeOffice.Service;

public class RegisterService : IRegisterService
{
    private IMemberRepo _memberRepo;

    public RegisterService(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
    }

    public async Task<string?> RegisterUser(RegisterDto registerDto)
    {
        var member = registerDto.ToMember();
        member.GetInvitationCode();
        return await _memberRepo.Register(member);
    }
}