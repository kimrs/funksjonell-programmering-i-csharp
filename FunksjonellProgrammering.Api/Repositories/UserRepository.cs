using Dapper;
using FunksjonellProgrammering.Api.GetUser;
using Domain = FunksjonellProgrammering.Api.CreateUser;

namespace FunksjonellProgrammering.Api.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<GetUser.Domain>> GetAll();
    Task Create(CreateUser.Domain domain);
}

public class UserRepository
    : IUserRepository
{
    private const string _getAllSql = """
        SELECT * FROM Users
    """;
    private const string _createUserSql = """
        INSERT INTO Users (Name, Role)
        VALUES (@Name, @Role)
    """;
    
    private readonly DataContext _dataDataContext;

    public UserRepository(DataContext dataContext)
        => _dataDataContext = dataContext;

    public async Task<IEnumerable<GetUser.Domain>> GetAll()
    {
        using var connection = _dataDataContext.CreateConnection();
        var entities = await connection.QueryAsync<Entity>(_getAllSql);
        return entities.Select(e => e.ToDomain());
    }

    public async Task Create(CreateUser.Domain domain)
    {
        using var connection = _dataDataContext.CreateConnection();
        await connection.ExecuteAsync(_createUserSql, domain);
    }
}