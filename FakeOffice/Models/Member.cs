namespace FakeOffice.Models;

public class Member
{
    public int agent_fk { get; set; }
    public string username { get; set; }
    public string? recommend { get; set; }
    public DateTime create_time { get; set; }
    public string? invitation_code { get; set; }
    public int pk { get; set; }
}