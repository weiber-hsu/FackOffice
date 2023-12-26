using FakeOffice.Models;

namespace FakeOffice.Service;

public interface IRegisterService
{
    Task RegisterUser(RegisterDto registerDto);
}