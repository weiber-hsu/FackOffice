using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service.Interface;

namespace FakeOffice.Service;

public class TransactionService : ITransactionService
{
    private IBorrowFeeRepo _borrowFeeRepo;

    public TransactionService(IBorrowFeeRepo borrowFeeRepo)
    {
        _borrowFeeRepo = borrowFeeRepo;
    }

    public void CreateTransactions(int trxNumber)
    {
        var borrowFees = new List<BorrowFee>();
        for (int i = 0; i < trxNumber; i++)
        {
           borrowFees.Add(new BorrowFee());   
        }

        _borrowFeeRepo.InsertBorrowFees(borrowFees);
    }
}