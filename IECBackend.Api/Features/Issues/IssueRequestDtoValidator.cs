using FluentValidation;
using IECBackend.Api.Features.Issues.UpdateIssue;

namespace IECBackend.Api.Features.Issues;

public class UpdateIssueRequestDtoValidator : AbstractValidator<IssueRequestDto>
{
    public UpdateIssueRequestDtoValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Описание проблемы обязательно для заполнения")
            .MaximumLength(1000).WithMessage("Описание не должно превышать 1000 символов")
            .MinimumLength(10).WithMessage("Описание должно содержать минимум 10 символов");
        
        RuleFor(x => x.Coordinates)
            .NotEmpty().WithMessage("Координаты обязательны для заполнения")
            .Matches(@"^-?\d+\.?\d*,\s*-?\d+\.?\d*$")
            .WithMessage("Координаты должны быть в формате 'широта,долгота'");
        
        RuleFor(x => x.TermOfElimination)
            .NotEmpty().WithMessage("Срок устранения обязателен для заполнения")
            .GreaterThan(DateTime.UtcNow).WithMessage("Срок устранения должен быть в будущем")
            .LessThan(DateTime.UtcNow.AddYears(1))
            .WithMessage("Срок устранения не может превышать 1 год от текущей даты");
        

    }
    private bool BeValidImageSize(byte[] image)
    {
        return image.Length <= 20 * 1024 * 1024;
    }
    private bool BeValidImageFormat(byte[] image)
    {
        if (image == null || image.Length < 4)
            return false;

        // Проверка сигнатур форматов изображений
        var jpeg = new byte[] { 0xFF, 0xD8, 0xFF };
        var png = new byte[] { 0x89, 0x50, 0x4E, 0x47 };
        var gif = new byte[] { 0x47, 0x49, 0x46, 0x38 };

        return image.Take(3).SequenceEqual(jpeg) ||
               image.Take(4).SequenceEqual(png) ||
               image.Take(4).SequenceEqual(gif);
    }
}