using Dapper;
using FunksjonellProgrammering.Api.Primitives;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.Api.CreateUser;

public interface IRepository
{
    void Create(Domain domain);
}

public class Repository
    : IRepository
{
    private static readonly SqlTemplate _createUserSql = """
        INSERT INTO Users (Name, Role)
        VALUES (@Name, @Role)
    """;
    
    private readonly ConnectionString _connectionString;

    public Repository(IConfiguration configuration)
        => _connectionString = configuration.GetConnectionString("ApiDb") ?? throw new ArgumentNullException();
    
    public void Create(Domain domain)
    {
        _connectionString.Save(_createUserSql)(domain.ToEntity());
        // throw new Exception("Uh-oh! Spaghetti O's");
        // using var connection = new SqliteConnection(_connectionString);
        // connection.Execute(CreateUserSql, domain.ToEntity());
    }
}