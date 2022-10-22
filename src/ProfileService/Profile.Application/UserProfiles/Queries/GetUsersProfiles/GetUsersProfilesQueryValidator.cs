using FluentValidation;

namespace Profile.Application.UserProfiles.Queries.GetUsersProfiles;

public class GetUsersProfilesQueryValidator : AbstractValidator<GetUsersProfilesQuery>
{
    public GetUsersProfilesQueryValidator()
    {
        RuleFor(x => x.Skip)
            .GreaterThanOrEqualTo(0).WithMessage("Can't skip negaitve nuumber of items.");

        RuleFor(x => x.Take)
            .GreaterThanOrEqualTo(1).WithMessage("Take must be in range of 1 to 25 items.")
            .LessThanOrEqualTo(25).WithMessage("Take must be in range of 1 to 25 items.");
    }
}
