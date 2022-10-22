using FluentValidation;

namespace Profile.Application.UserProfiles.Commands.CreateUserProfile;

public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
{
    public CreateUserProfileCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(25);

        RuleFor(x => x.Description)
            .MaximumLength(5000);
    }
}
