using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.UserApi;

public static class Read
{
    private static readonly SqlTemplate Sql = """
        SELECT * FROM Users WHERE Id = @Id
    """;

    public static Func<int, Option<User>> Configure(
        ConnectionString connectionString
    ) => param =>
    {
        try
        {
            var r = connectionString.Connect(
                c => c
                    .Query(Sql, new {Id = param})
                    .Select(User.Create)
                    .First());
             
            return Some(r);

        }
        catch (Exception e)
        {
            return None;
        }
    };
}