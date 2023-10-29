using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.GetUser;

public class Response
{
    public Response(
        Name name,
        Role role
    )
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }

    public Name Name { get; }
    public Role Role { get; }
}