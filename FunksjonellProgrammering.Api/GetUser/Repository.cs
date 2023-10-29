using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.GetUser;

public interface IRepository
{
    IEnumerable<Response> Handle(int id);
}

public class Repository
    : IRepository
{
    private static readonly SqlTemplate _selectSql = """SELECT * FROM Users WHERE Id = @Id""";

    private readonly ConnectionString _connectionString;

    public Repository(
        IConfiguration configuration
    )
        => _connectionString = configuration.GetConnectionString("ApiDb")
                               ?? throw new ArgumentNullException();

    public IEnumerable<Response> Handle(
        int id
    )
        => _connectionString
            .Retrieve<Dto>(_selectSql)(new {Id = id})
            .Select(x => x.ToResponse());

    private class Dto
    {
        private string? Name { get; set; }
        private string? Role { get; set; }
        
        public Response ToResponse()
            => new(Name, Role);
    }
}