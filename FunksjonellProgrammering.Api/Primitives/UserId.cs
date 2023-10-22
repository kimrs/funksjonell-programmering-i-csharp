namespace FunksjonellProgrammering.Api.Primitives;

public class UserId
{
    public static implicit operator int(UserId id) => id._value;
    public static implicit operator UserId(int i) => new(i);
    
    private readonly int _value;

    private UserId(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(nameof(value));
        }
        _value = value;
    }
}