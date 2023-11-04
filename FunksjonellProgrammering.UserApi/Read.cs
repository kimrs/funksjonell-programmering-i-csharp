using Dapper;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public static class Read
{
    private static readonly SqlTemplate Sql = """
        SELECT * FROM Users WHERE Id = @Id
    """;

    public static Func<int, IEnumerable<User>> Configure(
        ConnectionString connectionString
    ) => param => connectionString.Connect(
        c => c
            .Query(Sql, new {Id = param})
            .Select(User.Create)
    );
}