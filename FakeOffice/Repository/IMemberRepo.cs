using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IMemberRepo
{
    Task<string?> Register(Member member);
    Task<Member> Get(int memberId);
    Task<Member?> GetMemberByInvitationCode(string recommend);
    List<Member> GetAllMembersPkAndCreateDay();
}