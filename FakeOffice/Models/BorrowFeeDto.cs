namespace FakeOffice.Models;

public class BorrowFeeDto
{
    public int MemberFk { get; set; }
    public int Pk { get; set; }
    public int Type { get; set; }
    public decimal BorrowFee { get; set; }
    public DateTime? CreateTime { get; set; }

    public BorrowFeeDto GivenBorrowFeeDto(int memberFk, DateTime createTime)
    {
        var random = new Random();
        var endDate = createTime.AddMonths(18);
        var days = (endDate - createTime).Days;
        createTime += TimeSpan.FromDays(random.Next(days));
        return new BorrowFeeDto
        {
            MemberFk = memberFk,
            Type = 1,
            BorrowFee = random.Next(0,99999),
            CreateTime = createTime
        };
    }
}