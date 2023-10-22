using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.CreateUser;

public static class Extensions
{
    public static Domain ToDomain(this Dto d)
        => new (d.Name, d.Role);

    public static Entity ToEntity(this Domain d)
        => new(d.Name, d.Role);
}
