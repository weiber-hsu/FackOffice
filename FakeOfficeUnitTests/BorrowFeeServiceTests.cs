using FakeOffice.Models;
using FakeOffice.Repository;
using FakeOffice.Service;
using NSubstitute;

namespace FakeOfficeUnitTests;

[TestFixture]
public class BorrowFeeServiceTests
{
    private const int AnyTrxNumber = 999;
    private IBorrowFeeRepo _borrowFeeRepo;
    private IMemberRepo _memberRepo;
    private BorrowFeeService _borrowFeeService;

    [SetUp]
    public void SetUp()
    {
        _borrowFeeRepo = Substitute.For<IBorrowFeeRepo>();
        _memberRepo = Substitute.For<IMemberRepo>();
        _borrowFeeService = new BorrowFeeService(_borrowFeeRepo, _memberRepo);
    }

    [Test]
    public async Task should_call_borrow_fee_repo()
    {
        GivenMembersData(new Member());
        await _borrowFeeService.CreateRandomTransactions(AnyTrxNumber);
        await _borrowFeeRepo.Received().InsertBorrowFees(Arg.Any<BorrowFeeDto>());
    }

    [Test]
    public async Task should_call_borrow_fee_repo_with_3_Borrow_fee_data()
    {
        GivenMembersData(
            new Member() { pk = 1, create_time = DateTime.Now, },
            new Member() { pk = 2, create_time = DateTime.Now, },
            new Member() { pk = 3, create_time = DateTime.Now, }
            );
        await _borrowFeeService.CreateRandomTransactions(3);
        await _borrowFeeRepo.Received(3).InsertBorrowFees(Arg.Any<BorrowFeeDto>());
    }

    [Test]
    public async Task should_call_repo_to_get_all_member_pk_and_create_day()
    {
        GivenMembersData(new Member());
        await _borrowFeeService.CreateRandomTransactions(AnyTrxNumber);
        await _memberRepo.Received().GetAllMembersPkAndCreateDay();
    }

    private void GivenMembersData(params Member[] returnThis)
    {
        _memberRepo.GetAllMembersPkAndCreateDay().Returns(returnThis.ToList());
    }
}