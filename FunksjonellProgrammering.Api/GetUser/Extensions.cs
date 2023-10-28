
namespace FunksjonellProgrammering.Api.GetUser;

public static class Extensions
{

    public static Dto ToDto(this Domain d)
        => new(d.Id, d.Name, d.Role);
}