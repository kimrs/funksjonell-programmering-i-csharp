using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.UserApi.OOP.Repositories;

public interface IUserRepository
{
    User Read(UserId Id);
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

    public User Read(UserId Id)
    {
        try
        {
            int intId = Id;
            var users = _connectionString.Connect(c => c.Query(ReadSql, new { Id = intId })
                .Select(x => new User(x.Name, x.Role))
                .ToList());
            
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
            _connectionString.Connect(c => c.Execute(CreateSql, user));
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
