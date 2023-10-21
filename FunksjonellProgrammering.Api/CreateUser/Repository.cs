using Dapper;

namespace FunksjonellProgrammering.Api.CreateUser;

public interface IRepository
{
    Task Create(Domain domain);
}

public class Repository
    : IRepository
{
    private const string _createUserSql = """
        INSERT INTO Users (Name, Role)
        VALUES (@Name, @Role)
    """;
    
    private readonly DataContext _dataDataContext;

    public Repository(DataContext dataContext)
        => _dataDataContext = dataContext;
    
    public async Task Create(Domain domain)
    {
        using var connection = _dataDataContext.CreateConnection();
        await connection.ExecuteAsync(_createUserSql, domain.ToEntity());
    }
}