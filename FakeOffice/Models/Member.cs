using System.Security.Cryptography;
using System.Text;

namespace FakeOffice.Models;

public class Member
{
    public int agent_fk { get; set; }
    public string username { get; set; }
    public string? recommend { get; set; }
    public DateTime create_time { get; set; }
    public string? invitation_code { get; set; }
    public int pk { get; set; }

    public void GetInvitationCode()
    {
        var next = new RandomProvider().Next(0,999999999);
        var hashCode = DateTime.Now.GetHashCode();
        var beforeEncrypt = next.ToString() + hashCode.ToString();
        var afterEncrypt =  SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(beforeEncrypt));
        invitation_code = BitConverter.ToString(afterEncrypt).Replace("-", "").Substring(0,7);
    }

    public BorrowFeeDto CreateBorrowFeeDtoWithRandomDay(int month)
    {
        var random = new RandomProvider();
        var borrowFeeDto = new BorrowFeeDto
        {
            MemberFk = pk,
            BorrowFee = random.Next(0,99999),
            CreateTime =random.GetRandomDateAfter(create_time, month)
        };

        return borrowFeeDto;
    }
}