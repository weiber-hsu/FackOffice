using FakeOffice.Models;

namespace FakeOffice.Service.Interface;

public interface IBorrowFeeService
{
    Task CreateRandomTransactions(int trxNumber);
    Task CreateBorrowFees(Member member, int randomMonth);
}