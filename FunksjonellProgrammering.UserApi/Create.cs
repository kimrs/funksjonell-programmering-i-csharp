using Dapper;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public static class Create
{
    private static readonly SqlTemplate Sql = """
         INSERT INTO Users (Name, Role)
         VALUES (@Name, @Role)
     """;

    public static Func<User, Exceptional<Unit>> Configure(
        ConnectionString connectionString
    ) => param =>
    {
        try
        {
            connectionString.Connect(c => c.Execute(Sql, param));
        }
        catch (Exception e)
        {
            return e;
        }

        return Unit();
    };
}