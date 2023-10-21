namespace FunksjonellProgrammering.Api.CreateUser;

public class Domain
{
    public Domain(
        string name,
        int role
    )
    {
        Name = name;
        Role = role;
    }
    
    public string Name { get; }
    public int Role { get; }
}