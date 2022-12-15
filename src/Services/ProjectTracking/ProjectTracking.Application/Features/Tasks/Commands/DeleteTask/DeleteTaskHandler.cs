using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;

namespace ProjectTracking.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskHandler: IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var taskModel = await _taskRepository.GetByIdAsync(request.Id);
        if (taskModel is null) throw new DatabaseException($"Task with id {request.Id} not found");
        return await _taskRepository.DeleteAsync(taskModel);
    }
}