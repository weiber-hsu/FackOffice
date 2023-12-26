using FakeOffice.Models;

namespace FakeOffice.Service;

public interface IMemberRepo
{
    void Register(Member member);
}