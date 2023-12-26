using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service.Interface;

namespace FakeOffice.Service;

public class TransactionService : ITransactionService
{
    private readonly IBorrowFeeRepo _borrowFeeRepo;
    private readonly IMemberRepo _memberRepo;

    public TransactionService(IBorrowFeeRepo borrowFeeRepo, IMemberRepo memberRepo)
    {
        _borrowFeeRepo = borrowFeeRepo;
        _memberRepo = memberRepo;
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