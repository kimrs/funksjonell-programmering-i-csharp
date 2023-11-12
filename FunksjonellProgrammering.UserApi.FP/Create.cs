using Dapper;
using FunksjonellProgrammering.Shared;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public static class Create
{
    public static Func<User, Exceptional<Unit>> Configure(
        ConnectionString connectionString
    ) => param =>
    {
        try
        {
            connectionString.Connect(c => c.Execute(Constants.CreateSql, param));
        }
        catch (Exception e)
        {
            return e;
        }

        return Unit();
    };
}