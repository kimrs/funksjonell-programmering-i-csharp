using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.CreateUser;

public class Domain
{
    public Domain(
        Name name,
        int role
    )
    {
        Name = name;
        Role = role;
    }
    
    public Name Name { get; }
    public int Role { get; }
}