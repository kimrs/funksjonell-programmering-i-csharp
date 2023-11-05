using System.Data;
using Dapper;
using FunksjonellProgrammering.Shared.Primitives;

namespace FunksjonellProgrammering.Shared;

public class NameTypeHandler : SqlMapper.TypeHandler<Name>
{
    public override void SetValue(IDbDataParameter parameter, Name? value)
        => parameter.Value = value.ToString()
            ?? throw new ArgumentNullException(nameof(value));

    public override Name? Parse(object value)
        => value.ToString()
            ?? throw new ArgumentNullException(nameof(value));
}

public class RoleTypeHandler : SqlMapper.TypeHandler<Role>
{
    public override void SetValue(IDbDataParameter parameter, Role? value)
        => parameter.Value = value.ToString()
            ?? throw new ArgumentNullException(nameof(value));

    public override Role? Parse(object value)
        => value.ToString()
           ?? throw new ArgumentNullException(nameof(value));
}