namespace FakeOffice.Service.Interface;

public interface ITransactionService
{
    Task CreateRandomTransactions(int trxNumber);
}