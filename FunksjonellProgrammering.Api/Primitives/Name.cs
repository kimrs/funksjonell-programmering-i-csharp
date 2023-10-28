using System.Text.RegularExpressions;

namespace FunksjonellProgrammering.Api.Primitives;

public partial class Name
{
    private readonly string _value;
    public static implicit operator string(Name n) => n._value;
    public static implicit operator Name(string s) => new(s);

    private Name(string value)
    {
        IsValid(value);
        _value = value;
    }
    
    public override string ToString() => _value;

    /*
     *  Noe a'la dette promoterer secure by design
     */
    private static void IsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"{nameof(Name)} cannot be null or empty");
        }

        if (!StartWithCapitalLetter().IsMatch(value))
        {
            throw new ArgumentException($"{nameof(Name)} must start with a capital letter");
        }
    }

    [GeneratedRegex("^([A-Z][a-z]+ ?){1,5}$")]
    private static partial Regex StartWithCapitalLetter();
}