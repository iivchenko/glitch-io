using FluentValidation;
using Profile.Domain.UserProfileAggregate;

namespace Profile.Application.UserProfiles.Commands.CreateUserProfile;

public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(UserProfileConstraints.NameMaxLength);

        RuleFor(x => x.Description)
            .MaximumLength(UserProfileConstraints.DescriptionMaxLength);
    }
}
