using FluentValidation;

namespace Profile.Application.UserProfiles.Queries.GetUserProfile;

public class GetUserProfileQueryValidator : AbstractValidator<GetUserProfileQuery>
{
    public GetUserProfileQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
