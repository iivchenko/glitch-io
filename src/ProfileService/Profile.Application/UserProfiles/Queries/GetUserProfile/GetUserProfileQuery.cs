namespace Profile.Application.UserProfiles.Queries.GetUserProfile;

public sealed class GetUserProfileQuery : IRequest<UserProfileDto>
{
    public Guid Id { get; set; }
}
