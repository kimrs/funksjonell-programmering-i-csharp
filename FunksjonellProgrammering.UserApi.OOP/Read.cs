using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.UserApi.OOP;

public static class Read
{
    private static readonly SqlTemplate ReadSql = """
        SELECT * FROM Users WHERE Id = @Id
    """;
    
    public static Func<UserId, Exceptional<Option<User>>> Configure(
        ConnectionString connectionString
    ) => userId =>
    {
        try
        {
            int intId = userId;
            var users = connectionString.Connect(c
                => c.Query(ReadSql, new { Id = intId })
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