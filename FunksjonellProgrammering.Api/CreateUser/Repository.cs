using FunksjonellProgrammering.Api.Primitives;
using LaYumba.Functional;
using Unit = System.ValueTuple;

namespace FunksjonellProgrammering.Api.CreateUser;

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