using System.Text.RegularExpressions;

namespace FunksjonellProgrammering.Api.Primitives;

public class Name
{
    public static implicit operator string(Name n) => n._value;
    public static implicit operator Name(string s) => new(s);
    
    private readonly string _value;
    
    private Name(string value)
    {
        IsValid(value);
        _value = value;
    }

    /*
     *  Noe a'la dette promoterer secure by design
     */
    private void IsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"{nameof(Name)} cannot be null or empty");
        }

        if (!Regex.IsMatch(value, @"^([A-Z][a-z]+ ?){1,5}$"))
        {
            throw new ArgumentException($"{nameof(Name)} must start with a capital letter");
        }
    }

    public override string ToString() => _value;
}