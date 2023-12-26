using FakeOffice.Models;

namespace FakeOffice.Service;

public interface IRegisterService
{
    Task<string?> RegisterUser(RegisterDto registerDto);
}