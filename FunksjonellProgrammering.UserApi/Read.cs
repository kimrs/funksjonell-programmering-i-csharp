﻿global using LaYumba.Functional;
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
    ) => id =>
    {
        return connectionString.Connect(c => c
            .Query(Sql, new { Id = id })
            .Select(x => new User(x.Name, x.Role))
            .Match<User, Option<User>>(
                Empty: () => None,
                Otherwise: (user, _) => user)
        );
    };
}