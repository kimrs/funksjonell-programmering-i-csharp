using Dapper;

namespace FunksjonellProgrammering.Api.GetUser;

public interface IRepository
{
    Task<IEnumerable<Domain>> GetAll();
}

public class Repository
    : IRepository
{
    private const string _getAllSql = """
        SELECT * FROM Users
    """;
    
    private readonly DataContext _dataDataContext;

    public Repository(DataContext dataContext)
        => _dataDataContext = dataContext;

    public async Task<IEnumerable<Domain>> GetAll()
    {
        using var connection = _dataDataContext.CreateConnection();
        var entities = await connection.QueryAsync<Entity>(_getAllSql);
        return entities.Select(e => e.ToDomain());
    }
}