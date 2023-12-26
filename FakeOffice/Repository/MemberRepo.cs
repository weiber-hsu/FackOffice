﻿using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
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

    public async Task<string?> Register(Member member)
    {
        var sql = "INSERT INTO member (agent_fk, username, recommend, create_time, invitation_code, pk) " + 
                          $"VALUES ({member.agent_fk}, '{member.username}', '{member.recommend}', '{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}', '{member.invitation_code}', {member.pk})";
        await _dbConnection.QueryAsync(sql);
        return member.invitation_code;
    }

    public async Task<Member> Get(int memberId)
    {
        string sql = $"SELECT * From member where pk = '{memberId}' ";
        var result =( await _dbConnection.QueryAsync<Member>(sql)).FirstOrDefault();
        return result;
    }
}