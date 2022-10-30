using Microsoft.AspNetCore.Mvc;
using Profile.Application.UserProfiles.Queries;
using Profile.Application.UserProfiles.Queries.GetUsersProfiles;

namespace Profile.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UserProfileController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<UserProfileDto>> Get(int skip = 0, int take = 25)
    {
        return await Mediator.Send(new GetUsersProfilesQuery { Skip = skip, Take = take });
    }
}
