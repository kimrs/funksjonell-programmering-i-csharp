using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace FunksjonellProgrammering.Shared.Primitives;

public class ConnectionString
{
    private readonly string _value;
    public static implicit operator string(ConnectionString c) => c._value;

    public ConnectionString(IConfiguration config)
        => _value = config.GetConnectionString("ApiDb")
            ?? throw new ArgumentNullException(nameof(config));

    public R Connect<R>
    (
        Func<SqliteConnection, R> func
    )
    {
        using var connection = new SqliteConnection(_value);
        connection.Open();
        return func(connection);
    }
}