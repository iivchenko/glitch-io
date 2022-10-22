using MediatR;
using Profile.Application.Common.Interfaces;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Commands.CreateUserProfile;

public sealed class CreateUserProfileCommandHander : IRequestHandler<CreateUserProfileCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateUserProfileCommandHander(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = UserProfile.Create(request.Name, request.Description); 

        _context.Profiles.Add(profile);

        await _context.SaveChangesAsync(cancellationToken); // TODO: Introduce UnitOfWork

        return profile.Id;
    }
}
