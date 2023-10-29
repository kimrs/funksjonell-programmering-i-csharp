using System.Data;
using Dapper;
using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api;

public class NameTypeHandler : SqlMapper.TypeHandler<Name>
{
    public override void SetValue(IDbDataParameter parameter, Name? value)
        => parameter.Value = value.ToString();

    public override Name? Parse(object value)
        => value.ToString();
}

public class RoleTypeHandler : SqlMapper.TypeHandler<Role>
{
    public override void SetValue(IDbDataParameter parameter, Role? value)
        => parameter.Value = value.ToString();

    public override Role? Parse(object value)
        => value.ToString();
}
