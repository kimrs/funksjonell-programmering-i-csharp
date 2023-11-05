using System.Reactive;
using Dapper;
using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.UserApi.OOP;

public static class Create
{
    private static readonly SqlTemplate CreateSql = """
         INSERT INTO Users (Name, Role)
         VALUES (@Name, @Role)
     """;


    public static Func<User, Exceptional<Unit>> Configure(
        ConnectionString connectionString
    ) => user =>
    {
        try
        {
            connectionString.Connect(c
                => c.Execute(CreateSql, user));
        }
        catch (Exception e)
        {
            return e;
        }

        return Unit();
    };
    
}