namespace FakeOffice.Models;

public class RegisterDto
{
    public string? Recommend { get; set; }

    public string? UserName { get; set; }

    public Member ToMember()
    {
        return new Member()
        {
            username = UserName,
            recommend = Recommend,
            create_time = DateTime.Now
        };
    }
}