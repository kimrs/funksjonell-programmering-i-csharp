using FunksjonellProgrammering.Shared.Primitives;
using Microsoft.Data.Sqlite;

namespace FunksjonellProgrammering.UserApi;

public static class ConnectionStringExtension
{
        public static R Connect<R>
        (
                this ConnectionString connectionString,
                Func<SqliteConnection, R> func
        )
        {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                return func(connection);
        }
}