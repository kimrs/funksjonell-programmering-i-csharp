using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using Microsoft.Data.Sqlite;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.UserApi.OOP.Repositories;

public interface IUserRepository
{
    Exceptional<Option<User>> Read(UserId Id);
    Exceptional<Unit> Create(User Id);
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

    public Exceptional<Option<User>> Read(UserId Id)
    {
        try
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            int intId = Id;
            var users = connection
                .Query(ReadSql, new { Id = intId })
                .Select(User.Create);

            return users.Any()
                ? Some(users.First())
                : None;
        }
        catch (Exception e)
        {
            return e;
        }
    }

    public Exceptional<Unit> Create(User user)
    {
        try
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            connection.Execute(CreateSql, user);
        }
        catch (Exception e)
        {
            return e;
        }

        return Unit();
    }
}
