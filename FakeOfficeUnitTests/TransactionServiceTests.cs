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

    [SetUp]
    public void SetUp()
    {
        _borrowFeeRepo = Substitute.For<IBorrowFeeRepo>();
        _transactionService = new TransactionService(_borrowFeeRepo);
    }

    [Test]
    public void should_call_borrow_fee_repo()
    {
        _transactionService.CreateTransactions(AnyTrxNumber);
        _borrowFeeRepo.Received().InsertBorrowFees(Arg.Any<List<BorrowFee>>());
    }

    [Test]
    public void should_call_borrow_fee_repo_with_10_Borrow_fee_data()
    {
        _transactionService.CreateTransactions(10);
        _borrowFeeRepo.Received().InsertBorrowFees(Arg.Is<List<BorrowFee>>(l => l.Count == 10));
    }
}