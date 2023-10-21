namespace FunksjonellProgrammering.Api.GetUser;

public class Domain
{
    public Domain(int id, string name, int role)
    {
        Id = id;
        Name = name;
        Role = role;
    }
    
    public int Id { get; }
    public string Name { get; }
    public int Role { get; }
}