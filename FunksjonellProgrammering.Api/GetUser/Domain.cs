using FunksjonellProgrammering.Api.ValueObjects;

namespace FunksjonellProgrammering.Api.GetUser;

public class Domain
{
    public Domain(UserId id, Name name, int role)
    {
        Id = id;
        Name = name;
        Role = role;
    }
    
    public UserId Id { get; }
    public Name Name { get; }
    public int Role { get; }
}