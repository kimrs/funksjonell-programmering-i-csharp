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

    public User Read(UserId id)
    {
        try
        {
            return _connectionString.Connect(c => c.Query(ReadSql, new { Id = (int) id })
                .Select(x => new User(x.Name, x.Role))
                .SingleOrDefault()
            );
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
            throw new Exception("huff da");
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
