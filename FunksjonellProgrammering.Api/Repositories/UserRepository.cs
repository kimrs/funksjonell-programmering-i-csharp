using Dapper;
using FunksjonellProgrammering.Api.Entities;

namespace FunksjonellProgrammering.Api.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task Create(User user);
}

public class UserRepository
    : IUserRepository
{
    private const string _getAllSql = """
        SELECT * FROM Users
    """;
    private const string _createUserSql = """
        INSERT INTO Users (Id, Name, Role)
        VALUES (@Id, @Name, @Role)
    """;
    
    private readonly DataContext _dataDataContext;

    public UserRepository(DataContext dataContext)
        => _dataDataContext = dataContext;

    public async Task<IEnumerable<User>> GetAll()
    {
        using var connection = _dataDataContext.CreateConnection();
        return await connection.QueryAsync<User>(_getAllSql);
    }

    public async Task Create(User user)
    {
        using var connection = _dataDataContext.CreateConnection();
        await connection.ExecuteAsync(_createUserSql, user);
    }
}