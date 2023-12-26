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
    }
}