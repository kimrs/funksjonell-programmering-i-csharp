global using LaYumba.Functional;
global using Unit = System.ValueTuple;
global using static LaYumba.Functional.F;

using Dapper;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public static class Read
{
    private static readonly SqlTemplate Sql = """
        SELECT * FROM Users WHERE Id = @Id
    """;

    public static Func<int, Exceptional<Option<User>>> Configure(
        ConnectionString connectionString
    ) => param =>
    {
        try
        {
            var users = connectionString.Connect(c 
                => c.Query(Sql, new {Id = param})
                    .Select(User.Create));
            
            return users.Any()
                ? Some(users.First())
                : None;
        }
        catch (Exception e)
        {
            return e;
        }
    };
}