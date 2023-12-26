using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service.Interface;

namespace FakeOffice.Service;

public class TransactionService : ITransactionService
{
    private readonly IBorrowFeeRepo _borrowFeeRepo;
    private readonly IMemberRepo _memberRepo;
    private Random _random;

    public TransactionService(IBorrowFeeRepo borrowFeeRepo, IMemberRepo memberRepo)
    {
        _random = new Random();
        _borrowFeeRepo = borrowFeeRepo;
        _memberRepo = memberRepo;
    }

    public async Task CreateTransactions(int trxNumber)
    {
        var allMembersPkAndCreateDay = await _memberRepo.GetAllMembersPkAndCreateDay();
        var borrowFees = new List<BorrowFeeDto>();
        for (int i = 0; i < trxNumber; i++)
        {
            var member = allMembersPkAndCreateDay[_random.Next(0, allMembersPkAndCreateDay.Count-1)];
            borrowFees.Add(new BorrowFeeDto().GivenBorrowFeeDto(member.pk, member.create_time));
        }

        _borrowFeeRepo.InsertBorrowFees(borrowFees);
    }
}