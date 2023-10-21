namespace FunksjonellProgrammering.Api.CreateUser;

public static class Extensions
{
    public static Domain ToDomain(this Dto d)
        => new (d.Name, d.Role);
}
