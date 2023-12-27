using FakeOffice.Models;

namespace FakeOffice.Service.Interface;

public interface ITransactionService
{
    Task CreateRandomTransactions(int trxNumber);
    Task CreateTransactionsWith(Member member, int randomMonth);
}