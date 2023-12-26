using Dapper;
using FakeOffice.Models;
using FakeOffice.Service;
using MySql.Data.MySqlClient;

namespace FakeOffice.Repository;

public class MemberRepo : IMemberRepo
{
    public MySqlConnection _dbConnection;

    public MemberRepo(MySqlConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public void Register(Member member)
    {
        throw new NotImplementedException();
    }

    public async Task<Member> Get(int memberId)
    {
        string sql = "SELECT * From member";
        var queryAsync = await _dbConnection.QueryAsync(sql);
        return new Member();
    }
}