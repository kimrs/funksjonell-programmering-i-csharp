namespace FunksjonellProgrammering.Api.ValueObjects;

public class Name
{
    private string _value;

    public Name(string value)
    {
        _value = value;
    }

    public string Value => _value;
}