using FluentValidation;

namespace ProjectTracking.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.TaskName).NotEmpty().NotNull().MinimumLength(5)
            .WithMessage("Cant be null or empty, minimum 5 symbols");
        RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(10)
            .WithMessage("Cant be null or empty, minimum 10 symbols");
        RuleFor(x => x.Status).NotNull().NotEmpty().WithMessage("Status is required field");
    }
}