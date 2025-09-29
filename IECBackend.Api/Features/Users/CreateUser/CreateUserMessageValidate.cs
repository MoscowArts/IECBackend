using FluentValidation;

namespace IECBackend.Api.Features.Users.CreateUser;

public class CreateUserMessageValidate : AbstractValidator<CreateUserMessage>
{
    public CreateUserMessageValidate()
    {
        RuleFor(x => x.CreateUserRequestDto.Password)
            .NotEmpty()
            .Length(6, 30);

        RuleFor(x => x.CreateUserRequestDto.Fullname)
            .NotEmpty()
            .Length(5, 80);
        
        RuleFor(x => x.CreateUserRequestDto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.CreateUserRequestDto.Phone)
            .NotEmpty()
            .Length(11, 12)
            .Matches(@"^\+?\d+$");

        RuleFor(x => x.CreateUserRequestDto.Role)
            .IsInEnum();

        RuleFor(x => x.CreateUserRequestDto.Organization)
            .NotEmpty()
            .Length(1, 100);
    }
}