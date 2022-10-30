using Microsoft.AspNetCore.Mvc;
using Profile.Application.UserProfiles.Commands.CreateUserProfile;
using Profile.Application.UserProfiles.Commands.DeleteUserProfile;
using Profile.Application.UserProfiles.Queries;
using Profile.Application.UserProfiles.Queries.GetUserProfile;
using Profile.Application.UserProfiles.Queries.GetUsersProfiles;

namespace Profile.Api.Controllers;

[ApiController]
[Route("api/v1/user-profiles")]
public sealed class UserProfileController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<UserProfileDto>> Get(int skip = 0, int take = 25)
    {
        return await Mediator.Send(new GetUsersProfilesQuery { Skip = skip, Take = take });
    }

    [HttpGet("{id:guid}")]
    public async Task<UserProfileDto> Get(Guid id)
    {
        return await Mediator.Send(new GetUserProfileQuery { Id = id });
    }

    [HttpPost]
    public async Task<Guid> Post([FromBody] CreateUserProfileCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task Delete(Guid id)
    {
        await Mediator.Send(new DeleteUserProfileCommand { Id = id });
    }
}
