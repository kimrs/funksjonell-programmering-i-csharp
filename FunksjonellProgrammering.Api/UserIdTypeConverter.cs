using System.ComponentModel;
using System.Globalization;
using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api;

public class UserIdTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        => sourceType == typeof(int)
               || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        throw new Exception();
        UserId userId = (int)value;
        return userId;
    }
}