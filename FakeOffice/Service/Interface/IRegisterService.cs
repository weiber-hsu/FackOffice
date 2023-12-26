using FakeOffice.Models;

namespace FakeOffice.Service.Interface;

public interface IRegisterService
{
    Task<string?> RegisterUser(RegisterDto registerDto);
}