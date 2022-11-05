using Profile.Application.Common.Interfaces;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Commands.UpdateUserProfile;

public sealed class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, Unit>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserProfileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = _context.Profiles.Single(x => x.Id == request.Id);

        profile.UpdateName(UserProfileName.Create(request.UserName));
        profile.UpdateDescription(request.UserDescription);

        await _context.SaveChangesAsync(cancellationToken); // TODO: Introduce UnitOfWork

        return Unit.Value;
    }
}