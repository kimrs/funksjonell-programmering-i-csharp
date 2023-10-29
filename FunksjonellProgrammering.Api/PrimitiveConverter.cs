using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FunksjonellProgrammering.Api;

public class PrimitiveConverter<T, R> : JsonConverter<T>
{
    private readonly MethodInfo _rOperator = typeof(T).GetMethod("op_Implicit", new[] {typeof(R)})
                                           ?? throw new Exception($"{typeof(T)} must have implicit operator");
    
    private readonly MethodInfo _tOperator = typeof(T).GetMethod("op_Implicit", new[] {typeof(T)})
                                           ?? throw new Exception($"{typeof(T)} must have implicit operator");

    public override T Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        object parameter = reader.TokenType switch
        {
            JsonTokenType.String => reader.GetString(),
            JsonTokenType.Number => reader.GetInt64()
        };

        return (T)_rOperator.Invoke(null, new[] { parameter });
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var d =(R) _tOperator.Invoke(null, new[] {(object) value});
        if (d is int dint)
        {
            writer.WriteNumberValue(dint);
        }

        if (d is string dstr)
        {
            writer.WriteStringValue(dstr);
        }
    }
}