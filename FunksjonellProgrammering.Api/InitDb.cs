using System.Data;
using Dapper;
using FunksjonellProgrammering.Api.Primitives;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.Api;

public class InitDb
{
    private static readonly SqlTemplate _createUserTableSql = """
        DROP TABLE IF EXISTS Users;
        CREATE TABLE IF NOT EXISTS
        Users (
            Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            Name TEXT,
            Role INTEGER
        )
    """;

    private readonly ConnectionString _connectionString;

    public InitDb(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("ApiDb");

    public async Task Init()
    {
        await using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(_createUserTableSql);
    }
}