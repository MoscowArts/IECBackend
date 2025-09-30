using FluentValidation;

namespace IECBackend.Api.Features.WorkTask.CreateWorkTask;

public class CreateWorkTaskRequestDtoValidator : AbstractValidator<CreateWorkTaskRequestDto>
{
    public CreateWorkTaskRequestDtoValidator()
    {
        {
            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("ID проекта должен быть положительным числом");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название задачи обязательно для заполнения")
                .MaximumLength(200).WithMessage("Название задачи не должно превышать 200 символов")
                .MinimumLength(3).WithMessage("Название задачи должно содержать минимум 3 символа");

            RuleFor(x => x.PlannedStart)
                .NotEmpty().WithMessage("Планируемая дата начала обязательна для заполнения")
                .LessThan(x => x.PlannedEnd).WithMessage("Дата начала должна быть раньше даты окончания");

            RuleFor(x => x.PlannedEnd)
                .NotEmpty().WithMessage("Планируемая дата окончания обязательна для заполнения")
                .GreaterThan(x => x.PlannedStart).WithMessage("Дата окончания должна быть позже даты начала");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Статус задачи обязателен для заполнения")
                .Must(BeValidStatus).WithMessage("Недопустимый статус задачи. Допустимые значения: New, InProgress, Completed, Cancelled");
            
        }
        

    }
    private bool BeValidStatus(string status)
    {
        if (string.IsNullOrEmpty(status))
            return false;

        var validStatuses = new[] { "New", "InProgress", "Completed", "Cancelled", "Pending" };
        return validStatuses.Contains(status);
    }
}