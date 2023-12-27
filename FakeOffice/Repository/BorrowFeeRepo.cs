using Dapper;
using FakeOffice.Models;
using FakeOffice.Service;
using MySql.Data.MySqlClient;

namespace FakeOffice.Repository;

class BorrowFeeRepo : IBorrowFeeRepo
{
    public MySqlConnection _dbConnection;

    public BorrowFeeRepo(MySqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task InsertBorrowFees(BorrowFeeDto borrowFees)
    {
        var checkExistSql = $"SELECT count(1) FROM borrow_fee WHERE member_fk = {borrowFees.MemberFk}";
        var hasExistBorrowFee =( await _dbConnection.QueryAsync<int>(checkExistSql)).Single();

        borrowFees.Type = hasExistBorrowFee == 0
            ? 1
            : 2;

        var insertSql = $"INSERT INTO borrow_fee (member_fk, type, borrow_fee, create_time)" +
                $" VALUES ({borrowFees.MemberFk}, {borrowFees.Type}, {borrowFees.BorrowFee}, '{borrowFees.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}') ";

        await _dbConnection.QueryAsync(insertSql);
    }
}