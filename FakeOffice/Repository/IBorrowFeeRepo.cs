using FakeOffice.Models;

namespace FakeOffice.Repository;

public interface IBorrowFeeRepo
{
    void InsertBorrowFees(List<BorrowFeeDto> borrowFees);
}