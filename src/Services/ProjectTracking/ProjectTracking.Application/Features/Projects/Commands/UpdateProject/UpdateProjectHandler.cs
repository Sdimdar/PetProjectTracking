using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Domain.Helpers;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectHandler: IRequestHandler<UpdateProjectCommand,bool>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);
        if (project is null) throw new DatabaseException($"Project with id {request.Id} not found");
        if (request.ProjectName is not null) project.ProjectName = request.ProjectName;
        project.Priority = request.Priority;
        if (project.Status == ProjectStatusHelper.NotStarted && request.Status == BaseStatusHelper.Two)
        {
            project.StartDate = DateTime.Now;
            project.Status = ProjectStatusHelper.Active;
        }
        else if (project.Status == ProjectStatusHelper.Active && request.Status == BaseStatusHelper.Three)
        {
            project.EndDate = DateTime.Now;
            project.Status = ProjectStatusHelper.Complete;
        }
        else if (project.Status == ProjectStatusHelper.NotStarted && request.Status == BaseStatusHelper.One) { }
        else
        {
            throw new Exception(
                "You can not complete a project that has not been started / you cannot start a completed project");
        }
        var result = await _projectRepository.UpdateAsync(project);
        return result;

    }
}