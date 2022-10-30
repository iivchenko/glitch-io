using Profile.Application.Common.Interfaces;

namespace Profile.Application.UserProfiles.Queries.GetUserProfile;

public sealed class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserProfileQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = await _context.Profiles.FindAsync(request.Id);
       
        if (profile == null)
        {
            throw new Exception($"User profile with id {request.Id} does't exist!"); // TODO: Introduce not found exception
        }

        return _mapper.Map<UserProfileDto>(profile);
    }
}
