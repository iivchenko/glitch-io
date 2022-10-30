using Profile.Application.Common.Mapping;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Queries;

public sealed class UserProfileDto : IMapFrom<UserProfile>
{
    public Guid Id { get; set; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public void Mapping(AutoMapper.Profile profile)
    {
        profile.CreateMap<UserProfile, UserProfileDto>()
          .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name.Value));
    }
}
