using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.UserApi.OOP.Repositories;

public interface IUserRepository
{
    Option<User> Read(UserId Id);
    void Create(User Id);
}

public class UserRepository
    : IUserRepository
{
    private static readonly SqlTemplate ReadSql = """
        SELECT * FROM Users WHERE Id = @Id
    """;
    
    private static readonly SqlTemplate CreateSql = """
         INSERT INTO Users (Name, Role)
         VALUES (@Name, @Role)
     """;
    
    private readonly ConnectionString _connectionString;
    
    public UserRepository(ConnectionString connectionString)
    {
        _connectionString = connectionString;
    }

    public Option<User> Read(UserId Id)
    {
        try
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            int intId = Id;
            var users = connection.Query(ReadSql, new { Id = intId })
                .Select(User.Create)
                .ToList();
            
            return users.Any()
                ? users.First()
                : null;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void Create(User user)
    {
        try
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            connection.Execute(CreateSql, user);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
