namespace FakeOffice.Models;

public class RegisterDto
{
    public RegisterDto(RegisterRequest registerRequest)
    {
        UserName = "AnyUserName";
        Recommend = "AnyRecommend";
    }

    public string Recommend { get; set; }

    public string UserName { get; set; }
}