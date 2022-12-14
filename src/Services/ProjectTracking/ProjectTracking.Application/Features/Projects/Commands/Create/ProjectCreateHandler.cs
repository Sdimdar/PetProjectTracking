using System.ComponentModel.DataAnnotations;
using FluentValidation;
using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Domain.Entities;
using ProjectTracking.Domain.Helpers;
using ProjectTracking.Domain.Helpers.Enums;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace ProjectTracking.Application.Features.Projects.Commands.Create;

public class ProjectCreateHandler:IRequestHandler<ProjectCreateCommand,bool>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IValidator<ProjectCreateCommand> _validator;

    public ProjectCreateHandler(IProjectRepository projectRepository, IValidator<ProjectCreateCommand> validator)
    {
        _projectRepository = projectRepository;
        _validator = validator;
    }

    public async Task<bool> Handle(ProjectCreateCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validatorResult.IsValid) throw new FluentValidation.ValidationException(validatorResult.Errors);
        var project = new ProjectDbModel
        {
            ProjectName = request.ProjectName,
            Priority = request.Priority,
        };
        switch (request.Status)
        {
         case BaseStatusHelper.One: project.Status = ProjectStatusHelper.NotStarted;
             break;
         case BaseStatusHelper.Two: project.Status = ProjectStatusHelper.Active;
             project.StartDate = DateTime.Now;
             break;
         case BaseStatusHelper.Three: project.Status = ProjectStatusHelper.Complete;
             project.EndDate = DateTime.Now;
             break;
        }

        var response = await _projectRepository.AddAsync(project);
        return response;
    }
}