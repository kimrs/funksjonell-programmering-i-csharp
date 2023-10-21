namespace FunksjonellProgrammering.Api.GetUser;

public static class Extensions
{
    public static Domain ToDomain(this Entity e)
        => new(e.Id, e.Name, e.Role);

}