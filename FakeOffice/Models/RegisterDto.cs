namespace FakeOffice.Models;

public class RegisterDto
{
    public string? Recommend { get; set; }

    public string? UserName { get; set; }

    public Member ToMember()
    {
        return new Member()
        {
            UserName = UserName,
            Recommend = Recommend
        };
    }
}