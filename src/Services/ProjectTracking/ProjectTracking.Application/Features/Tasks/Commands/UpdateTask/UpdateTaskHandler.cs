using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Domain.Helpers;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, bool>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskModel = await _taskRepository.GetByIdAsync(request.Id);
        if (taskModel is null) throw new DatabaseException($"Task with id {request.Id} not found");
        if (request.TaskName is not null) taskModel.TaskName = request.TaskName;
        if (request.Description is not null) taskModel.Description = request.Description;
        taskModel.Priority = request.Priority;
        if (request.Status == BaseStatusHelper.One) taskModel.Status = TaskStatusHelper.ToDo;
        else if (request.Status == BaseStatusHelper.Two) taskModel.Status = TaskStatusHelper.InProgress;
        else if (request.Status == BaseStatusHelper.Three) taskModel.Status = TaskStatusHelper.Done;
        return await _taskRepository.UpdateAsync(taskModel);
    }
}