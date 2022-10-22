using Profile.Domain.Common;

namespace Profile.Domain.UserProfileAggregate;

public sealed class UserProfile : Entity, IAggregateRoot
{
    private UserProfile()
    {
        Name = string.Empty;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public static UserProfile Create(string name, string? descrtiption)
    {
        // TODO: add validation
        return new UserProfile
        {
            Name = name,
            Description = descrtiption
        };

        // TODO: Add User Profile Created Domain Event
    }
}
