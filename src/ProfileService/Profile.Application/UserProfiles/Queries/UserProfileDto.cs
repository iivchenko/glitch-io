using Profile.Application.Common.Mapping;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Queries;

public sealed class UserProfileDto : IMapFrom<UserProfile>
{
    public Guid Id { get; set; }

    public string? Name { get; init; }

    public string? Description { get; init; }
}
