using Profile.Application.Common.Mapping;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Queries;

public sealed class UserProfileDto : IMapFrom<UserProfile>
{
    public string? UserName { get; }

    public string? Description { get; }
}
