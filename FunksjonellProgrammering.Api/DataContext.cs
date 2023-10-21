using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.Api;

public class DataContext
{
    private const string _createUserTableSql = """
        DROP TABLE IF EXISTS Users;
        CREATE TABLE IF NOT EXISTS
        Users (
            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            Name TEXT,
            Role INTEGER
        )
    """;
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
        => _configuration = configuration;

    public IDbConnection CreateConnection()
        => new SqliteConnection(_configuration.GetConnectionString("ApiDb"));

    public async Task Init()
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync(_createUserTableSql);
    }
}