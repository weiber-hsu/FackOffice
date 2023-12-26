using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service.Interface;

namespace FakeOffice.Service;

public class TransactionService : ITransactionService
{
    private readonly IBorrowFeeRepo _borrowFeeRepo;

    public TransactionService(IBorrowFeeRepo borrowFeeRepo)
    {
        _borrowFeeRepo = borrowFeeRepo;
    }

    public void CreateTransactions(int trxNumber)
    {
        var borrowFees = new List<BorrowFeeDto>();
        for (int i = 0; i < trxNumber; i++)
        {
            borrowFees.Add(new BorrowFeeDto().GivenBorrowFeeDto(0, DateTime.Now));
        }

        _borrowFeeRepo.InsertBorrowFees(borrowFees);
    }
}