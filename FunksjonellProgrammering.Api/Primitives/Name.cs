using System.Text.RegularExpressions;

namespace FunksjonellProgrammering.Api.ValueObjects;

public class Name
{
    private readonly string _value;

    public Name(string value)
    {
        IsValid(value);
        _value = value;
    }

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

    public string Value => _value;
}