using RestEase;

namespace ClientWeb.Clients.ProfileService;

[BasePath("api/v1/user-profiles")]
public interface IProfileClient
{
    [Get]
    Task<IEnumerable<UserProfileDto>> Get([Query] int skip = 0, [Query] int take = 25);

    [Get("{id}")]
    Task<UserProfileDto> Get([Path] Guid id);

    [Post]
    Task<Guid> Post([Body] CreateUserProfileCommand command);

    [Put("{id}")]
    Task Put([Path] Guid id, [Body] UpdateUserProfileCommand command);

    [Delete("{id}")]
    Task Delete([Path] Guid id);
}