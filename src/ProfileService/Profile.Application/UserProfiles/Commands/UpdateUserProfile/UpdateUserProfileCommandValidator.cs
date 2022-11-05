using FluentValidation;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Commands.UpdateUserProfile;

public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
{
    public UpdateUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(UserProfileConstraints.NameMaxLength);

        RuleFor(x => x.UserDescription)
            .MaximumLength(UserProfileConstraints.DescriptionMaxLength);
    }
}