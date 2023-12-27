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
        var sql = $"IF EXISTS (SELECT 1 FROM borrow_fee WHERE member_fk = {borrowFees.MemberFk} " +
                           $"BEGIN INSERT INTO borrow_fee (member_fk, type, borrow_fee, create_time)" +
                           $" VALUES ({borrowFees.MemberFk}, 1, {borrowFees.BorrowFee}, '{borrowFees.CreateTime}') end "+
                           "else BEGIN INSERT INTO borrow_fee (member_fk, type, borrow_fee, create_time)" +
                           $" VALUES ({borrowFees.MemberFk}, 2, {borrowFees.BorrowFee}, '{borrowFees.CreateTime}') end ";

        await _dbConnection.QueryAsync(sql);
    }
}