using FunksjonellProgrammering.Api.Primitives;

namespace FunksjonellProgrammering.Api.GetUser;

public class Domain
{
    public Domain(
        UserId id,
        Name name,
        Role role
    )
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Role = role ?? throw new ArgumentNullException(nameof(role));
    }

    public UserId Id { get; }
    public Name Name { get; }
    public Role Role { get; }
}