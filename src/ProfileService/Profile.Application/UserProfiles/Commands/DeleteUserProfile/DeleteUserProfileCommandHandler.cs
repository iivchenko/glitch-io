using Profile.Application.Common.Interfaces;

namespace Profile.Application.UserProfiles.Commands.DeleteUserProfile;

public sealed class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserProfileCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles.FindAsync(request.Id);

        if (profile == null)
        {
            throw new Exception($"User profile with id {request.Id} does't exist!"); // TODO: Introduce NotFoundException
        }

        _context.Profiles.Remove(profile);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
