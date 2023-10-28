namespace FunksjonellProgrammering.Api.Primitives;

public enum RoleEnum
{
    SpaceExplorer = 0,
    TimeTraveler = 1,
    MadScientist = 2
}

public class Role
{
    public static implicit operator string(Role r) => $"{r._value}";
    public static implicit operator Role(string s) => new(s);
    
    private readonly RoleEnum _value;

    private Role(string s)
    {
        _value = RoleEnum.TryParse(s, out RoleEnum value)
            ? value
            : throw new ArgumentException($"{nameof(Role)} must be known");
    }

    public override string ToString()
        => $"{_value}";
}