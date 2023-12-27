namespace FakeOffice.Models;

public class BorrowFeeDto
{
    public int MemberFk { get; set; }
    public int Pk { get; set; }
    public int Type { get; set; }
    public decimal BorrowFee { get; set; }
    public DateTime CreateTime { get; set; }
}