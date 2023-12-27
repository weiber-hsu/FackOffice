using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IBorrowFeeRepo
{
    Task InsertBorrowFees(BorrowFeeDto borrowFees);
}