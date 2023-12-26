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
        string sql = $"SELECT * From member where pk = '{memberId}' ";
        var result =( await _dbConnection.QueryAsync(sql)).FirstOrDefault();
        return new Member()
        {
            UserName = result.username as string,
            Recommend = result.recommend as string,
            agent_fk = (int)result.agent_fk,
            invitation_code = result.invitation_code as string,
            create_time = (DateTime) result.create_time,
            pk = (int) result.pk
        };
    }
}