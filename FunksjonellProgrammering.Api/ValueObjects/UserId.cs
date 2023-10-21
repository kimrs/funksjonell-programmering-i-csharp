namespace FunksjonellProgrammering.Api.ValueObjects;

public class UserId
{
    private readonly int _value;

    public UserId(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException(nameof(value));
        }
        _value = value;
    }

    public int Value => _value;
}