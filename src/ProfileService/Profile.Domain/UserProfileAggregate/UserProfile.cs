using Profile.Domain.Common;

namespace Profile.Domain.UserProfileAggregate;

// TODO: Cover with unit tests
public sealed class UserProfile : Entity, IAggregateRoot
{
    private UserProfile()
    {
        Name = UserProfileName.Dummy; // TODO: Think on better solution
    }

    public UserProfileName Name { get; private set; }

    public string? Description { get; private set; }

    public void UpdateName(string name)
    {
        Name = UserProfileName.Create(name);
    }

    public void UpdateDescription(string? description)
    {
        Description = description;
    }

    public static UserProfile Create(UserProfileName name, string? descrtiption)
    {
        if (name == null)
        {
            throw new UserProfileException("Profile Name can't be NULL!");
        }

        // TODO: check name is not null
        // TODO: converty discription to value objecty
        // TODO: check description is not null???
        // TODO: add validation
        return new UserProfile
        {
            Name = name,
            Description = descrtiption
        };

        // TODO: Add User Profile Created Domain Event
    }
}
