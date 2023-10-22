using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.CreateUser;

public class Domain
{
    public Domain(
        Name name,
        Role? role
    )
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }
    
    public Name Name { get; }
    public Role Role { get; }
}