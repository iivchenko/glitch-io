using Profile.Domain.Common;

namespace Profile.Domain.UserProfileAggregate;

// TODO: Follow guidelines
public class UserProfileException : DomainException
{
    public UserProfileException(string message) 
        : base(message) { }
}
