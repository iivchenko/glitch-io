using MediatR;

namespace Profile.Application.UserProfiles.Commands.CreateUserProfile;

public sealed class CreateUserProfileCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
