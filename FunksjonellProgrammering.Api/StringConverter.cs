using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api;

public class StringConverter<T> : JsonConverter<T>
{
    private readonly MethodInfo _stringOperator = typeof(T).GetMethod("op_Implicit", new[] {typeof(string)})
                                           ?? throw new ArgumentException($"{typeof(T)} must have implicit operator");

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => (T)_stringOperator.Invoke(null, new[] { reader.GetString() });

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        => writer.WriteStringValue($"{value}");
}