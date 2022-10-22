using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Profile.Application.Common.Interfaces;

namespace Profile.Application.UserProfiles.Queries.GetUsersProfiles;

public sealed class GetUsersProfilesQueryHandler : IRequestHandler<GetUsersProfilesQuery, IEnumerable<UserProfileDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersProfilesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserProfileDto>> Handle(GetUsersProfilesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Profiles
                .Skip(request.Skip)
                .Take(request.Take)
                .ProjectTo<UserProfileDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken); // TODO: Improve paginated situations here
    }
}
