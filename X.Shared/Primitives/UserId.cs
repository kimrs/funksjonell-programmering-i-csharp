
namespace FunksjonellProgrammering.Shared.Primitives;

public class UserId
{
    public static implicit operator int(UserId id) => id._value;
    public static implicit operator UserId(int i) => new(i);
    
    private readonly int _value;

    private UserId(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("UserId cannot be less than 1");
        }
        _value = value;
    }

    public override string ToString()
        => $"{_value}";
}