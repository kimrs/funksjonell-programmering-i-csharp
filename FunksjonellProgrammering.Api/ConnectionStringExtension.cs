using Dapper;
using FunksjonellProgrammering.Api.Primitives;
using Microsoft.Data.Sqlite;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.Api;

public static class ConnectionStringExtension
{
        private static R Connect<R>
        (
                ConnectionString connectionString,
                Func<SqliteConnection, R> func
        )
        {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                return func(connection);
        }

        public static Func<object, IEnumerable<T>> Retrieve<T>
        (
                this ConnectionString connectionString,
                SqlTemplate sql
        )
        {
                return param => Connect(connectionString, c => c.Query<T>(sql, param));
        }

        public static Func<object, int> Save
        (
                this ConnectionString connectionString,
                SqlTemplate sql
        )
        {
                return param => Connect(connectionString, c => c.Execute(sql, param));
        }
}