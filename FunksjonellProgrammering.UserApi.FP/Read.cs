global using LaYumba.Functional;
global using Unit = System.ValueTuple;
global using static LaYumba.Functional.F;

using Dapper;
using FunksjonellProgrammering.Shared;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.UserApi;

public static class Read
{
    public static Func<int, Exceptional<Option<User>>> Configure(
        ConnectionString connectionString
    ) => id =>
    {
        return connectionString.Connect(c => c
            .Query(Constants.ReadSql, new { Id = id })
            .Select(x => new User(x.Name, x.Role))
            .Match<User, Option<User>>(
                Empty: () => None,
                Otherwise: (user, _) => user)
        );
    };
}