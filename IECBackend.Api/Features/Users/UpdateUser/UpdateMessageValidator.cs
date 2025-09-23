using FluentValidation;

namespace IECBackend.Api.Features.Users.UpdateUser;

public class UpdateMessageValidator : AbstractValidator<UpdateUserMessage>
{
    public UpdateMessageValidator()
    {
        // Правила для OldPassword
        RuleFor(x => x.UpdateUserRequestDto.OldPassword)
            .Length(6, 30).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.OldPassword))
            .WithMessage("Old password must be at least 8 characters long if provided.")
            .Must((dto, oldPassword) => !string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(dto.UpdateUserRequestDto.NewPassword))
            .WithMessage("Old password must be provided if new password is specified.");

        // Правила для NewPassword
        RuleFor(x => x.UpdateUserRequestDto.NewPassword)
            .Length(6, 30).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.NewPassword))
            .WithMessage("New password must be at least 8 characters long if provided.")
            .Must((dto, newPassword) => !string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(dto.UpdateUserRequestDto.OldPassword))
            .WithMessage("New password cannot be provided without old password.")
            .NotEqual(x => x.UpdateUserRequestDto.OldPassword).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.NewPassword) && !string.IsNullOrEmpty(x.UpdateUserRequestDto.OldPassword))
            .WithMessage("New password must be different from old password.");

        // Правила для Fullname
        RuleFor(x => x.UpdateUserRequestDto.Fullname)
            .MinimumLength(2).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Fullname))
            .WithMessage("Fullname must be at least 2 characters long if provided.")
            .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Fullname))
            .WithMessage("Fullname cannot exceed 100 characters.");

        // Правила для Email
        RuleFor(x => x.UpdateUserRequestDto.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Email))
            .WithMessage("Invalid email format.")
            .MaximumLength(254).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Email))
            .WithMessage("Email cannot exceed 254 characters.");

        // Правила для Phone
        RuleFor(x => x.UpdateUserRequestDto.Phone)
            .MinimumLength(10).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Phone))
            .WithMessage("Phone number must be at least 10 characters long if provided.")
            .MaximumLength(12).When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Phone))
            .WithMessage("Phone number cannot exceed 15 characters.")
            .Matches(@"^\+?\d+$").When(x => !string.IsNullOrEmpty(x.UpdateUserRequestDto.Phone))
            .WithMessage("Phone number must contain only digits and an optional leading '+'.");
    }
}