
namespace FunksjonellProgrammering.Api.GetUser;

public static class Extensions
{
    public static Domain ToDomain(this Entity e)
        => new(
            e.Id,
            e.Name,
            e.Role
        );

    public static Dto ToDto(this Domain d)
        => new(d.Id, d.Name, d.Role);
}