using Microsoft.Extensions.Configuration;

namespace FunksjonellProgrammering.Shared.Primitives;

public class ConnectionString
{
    private readonly string _value;
    public static implicit operator string(ConnectionString c) => c._value;

    public ConnectionString(IConfiguration config)
        => _value = config.GetConnectionString("ApiDb")
            ?? throw new ArgumentNullException(nameof(config));
}