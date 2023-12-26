using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service;
using NSubstitute;

namespace FakeOfficeUnitTests;

[TestFixture]
public class TransactionServiceTests
{
    private const int AnyTrxNumber = 999;
    private TransactionService _transactionService;
    private IBorrowFeeRepo _borrowFeeRepo;
    private IMemberRepo _memberRepo;

    [SetUp]
    public void SetUp()
    {
        _borrowFeeRepo = Substitute.For<IBorrowFeeRepo>();
        _memberRepo = Substitute.For<IMemberRepo>();
        _transactionService = new TransactionService(_borrowFeeRepo, _memberRepo);
    }

    [Test]
    public void should_call_borrow_fee_repo()
    {
        _transactionService.CreateTransactions(AnyTrxNumber);
        _borrowFeeRepo.Received().InsertBorrowFees(Arg.Any<List<BorrowFeeDto>>());
    }

    [Test]
    public void should_call_borrow_fee_repo_with_10_Borrow_fee_data()
    {
        _transactionService.CreateTransactions(10);
        _borrowFeeRepo.Received().InsertBorrowFees(Arg.Is<List<BorrowFeeDto>>(l => l.Count == 10));
    }

    [Test]
    public void should_call_repo_to_get_all_member_pk_and_create_day()
    {
        _transactionService.CreateTransactions(AnyTrxNumber);
        _memberRepo.Received().GetAllMembersPkAndCreateDay();
    }
}