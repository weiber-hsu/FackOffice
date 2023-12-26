namespace FakeOffice.Service.Interface;

public interface ITransactionService
{
    Task CreateTransactions(int trxNumber);
}