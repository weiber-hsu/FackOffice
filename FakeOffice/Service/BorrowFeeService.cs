using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service.Interface;

namespace FakeOffice.Service;

public class BorrowFeeService : IBorrowFeeService
{
    private readonly IBorrowFeeRepo _borrowFeeRepo;
    private readonly IMemberRepo _memberRepo;
    private readonly Random _random;

    public BorrowFeeService(IBorrowFeeRepo borrowFeeRepo, IMemberRepo memberRepo)
    {
        _random = new Random();
        _borrowFeeRepo = borrowFeeRepo;
        _memberRepo = memberRepo;
    }

    public async Task CreateRandomTransactions(int trxNumber)
    {
        var allMembersPkAndCreateDay = await _memberRepo.GetAllMembersPkAndCreateDay();
        if (allMembersPkAndCreateDay.Count == 0)
        {
            return;
        }
        for (var i = 0; i < trxNumber; i++)
        {
            var randomMember = allMembersPkAndCreateDay[_random.Next(0, allMembersPkAndCreateDay.Count - 1)];
            await CreateBorrowFees(randomMember, 18);
        }
    }

    public async Task CreateBorrowFees(Member member, int randomMonth)
    {
        var borrowFee = member.ToBorrowFeeDtoWith(randomMonth);
        await _borrowFeeRepo.InsertBorrowFees(borrowFee);
    }
}