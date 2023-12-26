using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IMemberRepo
{
    Task Register(Member member);
    Task<Member> Get(int memberId);
}