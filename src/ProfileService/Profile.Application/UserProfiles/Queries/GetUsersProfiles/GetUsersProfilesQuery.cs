namespace Profile.Application.UserProfiles.Queries.GetUsersProfiles;

public sealed class GetUsersProfilesQuery : IRequest<IEnumerable<UserProfileDto>>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}
