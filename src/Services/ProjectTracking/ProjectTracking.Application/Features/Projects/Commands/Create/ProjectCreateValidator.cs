using FluentValidation;

namespace ProjectTracking.Application.Features.Projects.Commands.Create;

public class ProjectCreateValidator:AbstractValidator<ProjectCreateCommand>
{
    public ProjectCreateValidator()
    {
        RuleFor(x => x.ProjectName).NotEmpty().NotNull().MinimumLength(5)
            .WithMessage("Cant be null or empty, minimum 5 symbols");
        RuleFor(x => x.Priority).NotEmpty().NotNull().WithMessage("Priority is required field");
        RuleFor(x => x.Status).NotNull().NotEmpty().WithMessage("Status is required field");
    }
}