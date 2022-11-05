namespace Profile.Application.UserProfiles.Commands.UpdateUserProfile;

public sealed class UpdateUserProfileCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public string UserName { get; init; }

    public string? UserDescription { get; init; }
}
