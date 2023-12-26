using FakeOffice.Models;

namespace FakeOffice.Service;

public interface IRegisterService
{
    void RegisterUser(RegisterDto registerDto);
}