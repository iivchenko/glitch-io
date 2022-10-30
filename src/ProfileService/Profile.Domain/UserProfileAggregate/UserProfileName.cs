using Profile.Domain.Common;
using System.Drawing;

namespace Profile.Domain.UserProfileAggregate;

public sealed class UserProfileName : ValueObject
{
    internal readonly static UserProfileName Dummy = new ("Dummy Profile");

    private UserProfileName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public override string ToString()
    {
        return Value;
    }

    public static UserProfileName Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new UserProfileException("User Profile Name can't be empty or blank!");
        }

        if (name.Length > UserProfileConstraints.NameMaxLength)
        {
            throw new UserProfileException($"User Profile Name shoule not exceed {UserProfileConstraints.NameMaxLength} symbols!");
        }

        return new UserProfileName(name);
    }

    public static implicit operator string(UserProfileName name)
    {
        return name.Value;
    }

    public static explicit operator UserProfileName(string name)
    {
        return Create(name);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
