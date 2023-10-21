using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.CreateUser;

public static class Extensions
{
    public static Domain ToDomain(this Dto d)
        => new (new Name(d.Name), d.Role);

    public static Entity ToEntity(this Domain d)
        => new(d.Name.Value, d.Role);
}
