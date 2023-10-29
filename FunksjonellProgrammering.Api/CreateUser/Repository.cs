using FunksjonellProgrammering.Api.Primitives;

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
        => _connectionString = configuration.GetConnectionString("ApiDb")
                               ?? throw new ArgumentNullException();
    
    public void Create(Domain domain)
        => _connectionString.Save(_createUserSql)(Dto.CreateFrom(domain));

    private record Dto(string Name, string Role)
    {
        public static Dto CreateFrom(Domain domain)
            => new(domain.Name, domain.Role);
    }
}