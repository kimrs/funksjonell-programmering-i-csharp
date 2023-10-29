using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.CreateUser;

public class Request
{
    public Request(
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