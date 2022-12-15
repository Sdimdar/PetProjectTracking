using FluentValidation;
using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Domain.Entities;
using ProjectTracking.Domain.Helpers;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskHandler : IRequestHandler<CreateTaskCommand,bool>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IValidator<CreateTaskCommand> _validator;

    public CreateTaskHandler(ITaskRepository taskRepository, IValidator<CreateTaskCommand> validator, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _validator = validator;
        _projectRepository = projectRepository;
    }

    
    public async Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var validatorResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);
        if (await _projectRepository.GetByIdAsync(request.ProjectId) is null)
            throw new DatabaseException($"Project with id {request.ProjectId} not found");
        var taskModel = new TaskDbModel
        {
            ProjectId = request.ProjectId,
            TaskName = request.TaskName,
            Description = request.Description,
            Priority = request.Priority
        };
        switch (request.Status)
        {
            case BaseStatusHelper.One: taskModel.Status = TaskStatusHelper.ToDo;
                break;
            case BaseStatusHelper.Two: taskModel.Status = TaskStatusHelper.InProgress;
                break;
            case BaseStatusHelper.Three: taskModel.Status = TaskStatusHelper.Done;
                break;
        }

        return await _taskRepository.AddAsync(taskModel);

    }
}