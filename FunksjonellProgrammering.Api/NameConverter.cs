using System.Text.Json;
using System.Text.Json.Serialization;
using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api;

public class NameConverter : JsonConverter<Name>
{
    public override Name Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetString() ?? throw new ArgumentNullException($"{typeof(Name)}");

    public override void Write(Utf8JsonWriter writer, Name value, JsonSerializerOptions options)
        => writer.WriteStringValue(value);
}