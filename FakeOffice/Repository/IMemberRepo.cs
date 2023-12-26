using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IMemberRepo
{
    Task<string?> Register(Member member);
    Task<Member> Get(int memberId);
}