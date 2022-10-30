using FluentValidation;

namespace Profile.Application.UserProfiles.Commands.DeleteUserProfile;

public class DeleteUserProfileCommandValidator : AbstractValidator<DeleteUserProfileCommand>
{
    public DeleteUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}