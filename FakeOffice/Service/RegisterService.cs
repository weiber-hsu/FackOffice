using FakeOffice.Models;

namespace FakeOffice.Service;

public class RegisterService : IRegisterService
{
    private IMemberRepo _memberRepo;

    public RegisterService(IMemberRepo memberRepo)
    {
        _memberRepo = memberRepo;
    }

    public void RegisterUser(RegisterDto registerDto)
    {
        
    }
}