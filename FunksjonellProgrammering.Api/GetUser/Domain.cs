using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.GetUser;

public class Domain
{
    public Domain(UserId id, Name name, Role role)
    {
        Id = id;
        Name = name;
        Role = role;
    }
    
    public UserId Id { get; }
    public Name Name { get; }
    public Role Role { get; }
}