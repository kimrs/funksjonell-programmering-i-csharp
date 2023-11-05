using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.Shared;

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

    public InitDb(ConnectionString connectionString)
        => _connectionString = connectionString;

    public async Task Init()
    {
        await using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(_createUserTableSql);
    }
}