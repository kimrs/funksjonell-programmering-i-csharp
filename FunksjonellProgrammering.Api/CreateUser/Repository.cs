using System.Runtime.InteropServices.JavaScript;
using FunksjonellProgrammering.Api.Primitives;
using LaYumba.Functional;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Unit = System.ValueTuple;

namespace FunksjonellProgrammering.Api.CreateUser;

public static class CreateHandler
{
     private static readonly SqlTemplate _createUserSql = """
         INSERT INTO Users (Name, Role)
         VALUES (@Name, @Role)
     """;
     
    public static Func<Request, int> Configure(
        IConfiguration config
    )
    {
        ConnectionString connectionString = config.GetConnectionString("ApiDb");
        var save = connectionString.Save(_createUserSql);

        return request => save(request);
    }
}

public interface IRepository
{
    int Handle(Request request);
}

// public class Repository
//     : IRepository
// {
//     private static readonly SqlTemplate _createUserSql = """
//         INSERT INTO Users (Name, Role)
//         VALUES (@Name, @Role)
//     """;
//     
//     public Func<Request, int> Handle { get; }
//
//     public Repository(
//         IConfiguration configuration
//     )
//     {
//          ConnectionString connectionString = configuration.GetConnectionString("ApiDb")
//                             ?? throw new Exception("Connection string is missing");
//         Handle = connectionString.Save(_createUserSql);
//     }
// }