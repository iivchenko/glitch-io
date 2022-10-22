using AutoMapper;
using MediatR;
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
            throw new Exception();
        }

        return _mapper.Map<UserProfileDto>(profile);
    }
}
