using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.GetUser;

public static class Extensions
{
    public static Domain ToDomain(this Entity e)
        => new(
            new UserId(e.Id),
            new Name(e.Name),
            (Role)e.Role
        );

    public static Dto ToDto(this Domain d)
        => new(d.Id.Value, d.Name.Value, d.Role);
}