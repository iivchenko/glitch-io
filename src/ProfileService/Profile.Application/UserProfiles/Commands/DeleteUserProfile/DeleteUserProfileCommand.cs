using MediatR;

namespace Profile.Application.UserProfiles.Commands.DeleteUserProfile;

// TODO: Its just a temporary command necessary to build MVP UI -> raplace with deactivate functinality in the future
public sealed class DeleteUserProfileCommand : IRequest
{
    public Guid Id { get; init; }
}